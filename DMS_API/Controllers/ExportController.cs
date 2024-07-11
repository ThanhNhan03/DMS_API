﻿using AutoMapper;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportExcel()
        {
            using (var package = new ExcelPackage())
            {
                await AddBookingsSheet(package);
                await AddAppUsersSheet(package);
                await AddOrdersSheet(package);
                await AddRoomsSheet(package);

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "ExportData.xlsx";

                return File(stream, contentType, fileName);
            }
        }

        private async Task AddBookingsSheet(ExcelPackage package)
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            var bookingDtos = _mapper.Map<BookingDTO[]>(bookings);

            var worksheet = package.Workbook.Worksheets.Add("Bookings");

            // Add header row
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "RoomName";
            worksheet.Cells[1, 3].Value = "UserName";
            worksheet.Cells[1, 4].Value = "RoomType";
            worksheet.Cells[1, 5].Value = "BookingDate";
            worksheet.Cells[1, 6].Value = "StartDate";
            worksheet.Cells[1, 7].Value = "EndDate";
            worksheet.Cells[1, 8].Value = "TotalPrice";
            worksheet.Cells[1, 9].Value = "Status";

            // Add data rows
            for (int i = 0; i < bookingDtos.Length; i++)
            {
                var booking = bookingDtos[i];
                worksheet.Cells[i + 2, 1].Value = booking.Id.ToString();
                worksheet.Cells[i + 2, 2].Value = booking.RoomName;
                worksheet.Cells[i + 2, 3].Value = booking.UserName;
                worksheet.Cells[i + 2, 4].Value = booking.RoomType;
                worksheet.Cells[i + 2, 5].Value = booking.BookingDate.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[i + 2, 6].Value = booking.StartDate.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[i + 2, 7].Value = booking.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[i + 2, 8].Value = booking.TotalPrice;
                worksheet.Cells[i + 2, 9].Value = booking.Status;
            }

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }

        private async Task AddAppUsersSheet(ExcelPackage package)
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync();
            var userDtos = _mapper.Map<AppUserDTO[]>(users);

            var worksheet = package.Workbook.Worksheets.Add("AppUsers");

            // Add header row
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "UserName";
            worksheet.Cells[1, 3].Value = "Email";
            worksheet.Cells[1, 4].Value = "FirstName";
            worksheet.Cells[1, 5].Value = "LastName";
            worksheet.Cells[1, 6].Value = "Gender";
            worksheet.Cells[1, 7].Value = "DateOfBirth";
            worksheet.Cells[1, 8].Value = "Address";
            worksheet.Cells[1, 9].Value = "Description";
            worksheet.Cells[1, 10].Value = "Picture";
            worksheet.Cells[1, 11].Value = "PhoneNumber";
            worksheet.Cells[1, 12].Value = "Balance";

            // Add data rows
            for (int i = 0; i < userDtos.Length; i++)
            {
                var user = userDtos[i];
                worksheet.Cells[i + 2, 1].Value = user.Id;
                worksheet.Cells[i + 2, 2].Value = user.UserName;
                worksheet.Cells[i + 2, 3].Value = user.Email;
                worksheet.Cells[i + 2, 4].Value = user.FirstName;
                worksheet.Cells[i + 2, 5].Value = user.LastName;
                worksheet.Cells[i + 2, 6].Value = user.Gender;
                worksheet.Cells[i + 2, 7].Value = user.DateOfBirth?.ToString("yyyy-MM-dd");
                worksheet.Cells[i + 2, 8].Value = user.Address;
                worksheet.Cells[i + 2, 9].Value = user.Description;
                worksheet.Cells[i + 2, 10].Value = user.Picture;
                worksheet.Cells[i + 2, 11].Value = user.PhoneNumber;
                worksheet.Cells[i + 2, 12].Value = user.Balance?.ToString();
            }

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }

        private async Task AddOrdersSheet(ExcelPackage package)
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync();
            var orderDtos = _mapper.Map<OrderDTO[]>(orders);

            var worksheet = package.Workbook.Worksheets.Add("Orders");

            // Add header row
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "UserId";
            worksheet.Cells[1, 3].Value = "OrderReference";
            worksheet.Cells[1, 4].Value = "CreatedDate";
            worksheet.Cells[1, 5].Value = "Status";
            worksheet.Cells[1, 6].Value = "Amount";

            // Add data rows
            for (int i = 0; i < orderDtos.Length; i++)
            {
                var order = orderDtos[i];
                worksheet.Cells[i + 2, 1].Value = order.Id.ToString();
                worksheet.Cells[i + 2, 2].Value = order.UserId.ToString();
                worksheet.Cells[i + 2, 3].Value = order.OrderReference;
                worksheet.Cells[i + 2, 4].Value = order.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[i + 2, 5].Value = order.Status;
                worksheet.Cells[i + 2, 6].Value = order.Amount;
            }

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }

        private async Task AddRoomsSheet(ExcelPackage package)
        {
            var rooms = await _unitOfWork.Rooms.GetAllAsync();
            var roomDtos = _mapper.Map<RoomDTO[]>(rooms);

            var worksheet = package.Workbook.Worksheets.Add("Rooms");

            // Add header row
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Status";
            worksheet.Cells[1, 4].Value = "Description";
            worksheet.Cells[1, 5].Value = "Capacity";
            worksheet.Cells[1, 6].Value = "HouseName";
            worksheet.Cells[1, 7].Value = "FloorName";
            worksheet.Cells[1, 8].Value = "DormName";
            worksheet.Cells[1, 9].Value = "RoomType";
            worksheet.Cells[1, 10].Value = "Price";

            // Add data rows
            for (int i = 0; i < roomDtos.Length; i++)
            {
                var room = roomDtos[i];
                worksheet.Cells[i + 2, 1].Value = room.Id.ToString();
                worksheet.Cells[i + 2, 2].Value = room.Name;
                worksheet.Cells[i + 2, 3].Value = room.Status;
                worksheet.Cells[i + 2, 4].Value = room.Description;
                worksheet.Cells[i + 2, 5].Value = room.Capacity;
                worksheet.Cells[i + 2, 6].Value = room.HouseName;
                worksheet.Cells[i + 2, 7].Value = room.FloorName;
                worksheet.Cells[i + 2, 8].Value = room.DormName;
                worksheet.Cells[i + 2, 9].Value = room.RoomType;
                worksheet.Cells[i + 2, 10].Value = room.Price;
            }

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
        }
    }
}
