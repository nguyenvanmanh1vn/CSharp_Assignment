using System.Threading.Tasks;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public interface IBorrowRequestServices
    {
        // int[] arrayBookIds(BorrowRequestDTO borrowRequestDTO);
        bool IsBRInABRValid(BorrowRequestDTO borrowRequestDTO);
        bool IsNumberOfTimesBRInMonthValid(BorrowRequestDTO borrowRequestDTO);
        BorrowRequest CreateBorrowRequest(BorrowRequestDTO borrowRequestDTO);
        void CreateBorrowRequestDetails(BorrowRequestDTO borrowRequestDTO);
    }
}