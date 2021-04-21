using System.Threading.Tasks;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public interface IBorrowingRequestServices
    {
        int[] arrayBookIds(BorrowingRequestDTO borrowingRequestDTO);
        bool IsBRInABRValid(int[] arrayBookIds, BorrowingRequestDTO borrowingRequestDTO);
        bool IsNumberOfTimesBRInMonthValid(BorrowingRequestDTO borrowingRequestDTO);
        BorrowingRequest CreateBorrowingRequest(int[] arrayBookIds, BorrowingRequestDTO borrowingRequestDTO);
        void CreateBorrowingRequestDetails(int bRId, int[] arrayBookIds);
    }
}