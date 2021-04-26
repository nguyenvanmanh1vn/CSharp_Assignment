using System.Threading.Tasks;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public interface IBorrowRequestServices
    {
        int[] arrayBookIds(BorrowRequestDTO borrowRequestDTO);
        bool IsBRInABRValid(int[] arrayBookIds, BorrowRequestDTO borrowRequestDTO);
        bool IsNumberOfTimesBRInMonthValid(BorrowRequestDTO borrowRequestDTO);
        BorrowRequest CreateBorrowRequest(int[] arrayBookIds, BorrowRequestDTO borrowRequestDTO);
        void CreateBorrowRequestDetails(int bRId, int[] arrayBookIds);
    }
}