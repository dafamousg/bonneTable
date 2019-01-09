using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseModel> ClientBookTable(BookingRequestModel bookingRequest);
        Task<BookingResponseModel> AdminBookTable(BookingRequestModel bookingRequest);
        Task<BookingResponseModel> EditBooking(BookingRequestModel bookingRequest, Guid id);
        Task<BookingResponseModel> Get(DateTime dateTime);
        Task<BookingResponseModel> Get(Guid bookingId);
        Task<BookingResponseModel> Get();
        Task<BookingResponseModel> SearchByEmail(string email);
        Task<BookingResponseModel> AdminCancelBooking(Guid id);
    }
}
