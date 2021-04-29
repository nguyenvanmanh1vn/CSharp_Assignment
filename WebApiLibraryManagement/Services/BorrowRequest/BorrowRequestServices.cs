using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public class BorrowRequestServices : IBorrowRequestServices

    {
        private readonly IBorrowRequestRepository _repository;
        private readonly IBorrowRequestDetailsRepository _bDRepository;
        public BorrowRequestServices(IBorrowRequestRepository repository, IBorrowRequestDetailsRepository bDRepository)
        {
            _repository = repository;
            _bDRepository = bDRepository;
        }

        // public int[] arrayBookIds(BorrowRequestDTO borrowRequestDTO)
        // {
        //     return Array.ConvertAll(borrowRequestDTO.BorrowBooks.Split(','), Int32.Parse);
        //     /* Front End:
        //      * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
        //     */
        // }

        public bool IsNumberOfTimesBRInMonthValid(BorrowRequestDTO borrowRequestDTO)
        {

            int numberOfBorrowRequestsInMonth = _repository.GetByQueryConditions().Count(br => br.UserId == borrowRequestDTO.UserId && br.CreatedDate.Month == DateTime.Now.Month);
            if (numberOfBorrowRequestsInMonth >= 3)
            {
                return false;
            }
            return true;
        }

        public bool IsBRInABRValid(BorrowRequestDTO borrowRequestDTO)
        {
            if (borrowRequestDTO.BorrowBooks.Length > 5)
            {
                return false;

            }
            return true;
        }

        public BorrowRequest CreateBorrowRequest(BorrowRequestDTO borrowRequestDTO)
        {

            var entity = new BorrowRequest
            {
                UserId = borrowRequestDTO.UserId,
                Status = "Waiting",
                CreatedDate = DateTime.Now
            };

            _repository.Insert(entity);
            return entity;
        }

        public void CreateBorrowRequestDetails(BorrowRequestDTO borrowRequestDTO)
        {
            foreach (BorrowRequest book in borrowRequestDTO.BorrowBooks)
            {
                var entityRequestDetails = new BorrowRequestDetail
                {
                    BookId = book.Id,
                    BorrowingRequestId = book.Id,
                };
                _bDRepository.Insert(entityRequestDetails);
            }
        }
    }
}