using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Services
{
    public interface IBorrowingRequestServices
    {
        BorrowingRequest CreateBorrowingRequest(BorrowingRequestDTO borrowingRequestDTO);
        bool IsNumberOfTimesBRInMonthValid(BorrowingRequestDTO borrowingRequestDTO);
        bool IsBRInABRValid(BorrowingRequestDTO borrowingRequestDTO);
    }
}