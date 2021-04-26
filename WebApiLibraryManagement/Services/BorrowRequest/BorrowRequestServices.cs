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

        public int[] arrayBookIds(BorrowRequestDTO borrowRequestDTO)
        {
            return Array.ConvertAll(borrowRequestDTO.BorrowBooks.Split(','), Int32.Parse);
            /* Front End:
             * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
            */
        }

        public bool IsNumberOfTimesBRInMonthValid(BorrowRequestDTO borrowRequestDTO)
        {

            int numberOfBorrowRequestsInMonth = _repository.GetByQueryConditions().Count(br => br.UserId == borrowRequestDTO.UserId && br.CreatedDate.Month == DateTime.Now.Month);
            if (numberOfBorrowRequestsInMonth >= 3)
            {
                return false;
            }
            return true;
        }

        public bool IsBRInABRValid(int[] arrayBookIds, BorrowRequestDTO borrowRequestDTO)
        {
            if (arrayBookIds.Length > 5)
            {
                return false;

            }
            return true;
        }

        public BorrowRequest CreateBorrowRequest(int[] arrayBookIds, BorrowRequestDTO borrowRequestDTO)
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

        public void CreateBorrowRequestDetails(int bRId, int[] arrayBookIds)
        {
            foreach (int bookId in arrayBookIds)
            {
                var entityRequestDetails = new BorrowRequestDetail
                {
                    BookId = bookId,
                    BorrowingRequestId = bRId,
                };
                _bDRepository.Insert(entityRequestDetails);
            }
        }
    }
}