using AutoMapper;
using DMS_API.Repository.Interface;
using DMS_API.Services;
using DMS_API.VNPay;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IVNPayService _vnPayService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public PaymentsController(IVNPayService vnPayService, IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _vnPayService = vnPayService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        // POST: api/payments/create
        [HttpPost("create")]
        public IActionResult CreatePayment([FromBody] VnPaymentRequest model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var paymentUrl = _vnPayService.CreatePaymentURLAsync(HttpContext, model);
            return Ok(new { url = paymentUrl });
        }

        // GET: api/payments/execute
        [HttpGet("execute")]
        public async Task<IActionResult> ExecutePayment()
        {
            var queryCollection = HttpContext.Request.Query;
            var paymentResponse = _vnPayService.PaymentExecute(queryCollection);

            if (!paymentResponse.Success)
            {
                return BadRequest(new { message = "Payment verification failed." });
            }

            // Retrieve the order by order reference
            var order = await _unitOfWork.Orders.GetByOrderReferenceAsync(paymentResponse.OrderId);
            if (order == null)
            {
                return NotFound(new { message = "Order not found for the given transaction ID." });
            }

            var userId = order.UserId;
            var amount = paymentResponse.Amount / 100; // Convert back to VND

            var updateResult = await _vnPayService.UpdateUserBalance(userId, amount);
            if (!updateResult)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update user balance." });
            }

            // Update order status
            order.Status = "Completed";
            await _unitOfWork.SaveChanges();

            // Retrieve user information to send email
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Compose email content
            var emailSubject = "Payment Receipt";
            var emailMessage = $"Dear {user.UserName},\n\nYour payment of {amount} VND has been successfully processed.\n\nOrder Details:\nOrder ID: {order.OrderReference}\nAmount: {amount} VND\nStatus: Completed\n\nThank you for your payment.\n\nBest regards,\nDMS Team";

            // Send email
            await _emailService.SendEmailAsync(toEmail: user.Email, emailSubject, emailMessage);

            return Ok(paymentResponse);
        }
    }
}
