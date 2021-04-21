using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public class BorrowingRequestServices : ControllerBase, IBorrowingRequestServices

    {
        protected readonly IBorrowingRequestRepository _repository;
        protected readonly IBorrowingRequestDetailsRepository _bRDRepository;
        public BorrowingRequestServices(IBorrowingRequestRepository repository, IBorrowingRequestDetailsRepository bRDRepository)
        {
            _repository = repository;
            _bRDRepository = bRDRepository;
        }
        public BorrowingRequest CreateBorrowingRequest(BorrowingRequestDTO borrowingRequestDTO)
        {
            int[] arrayBookIds = Array.ConvertAll(borrowingRequestDTO.BorrowBooks.Split(','), Int32.Parse);
            /* Front End:
             * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
            */

            var entity = new BorrowingRequest
            {
                UserId = borrowingRequestDTO.UserId,
                Status = "Waiting",
                CreatedDate = DateTime.Now
            };

            _repository.Insert(entity);

            foreach (int bookId in arrayBookIds)
            {
                var entityRequestDetails = new BorrowingRequestDetail
                {
                    BookId = bookId,
                    BorrowingRequestId = entity.Id,
                };
                _bRDRepository.Insert(entityRequestDetails);
            }
            return entity;
        }

        public bool IsBRInABRValid(BorrowingRequestDTO borrowingRequestDTO)
        {
            int[] arrayBookIds = Array.ConvertAll(borrowingRequestDTO.BorrowBooks.Split(','), Int32.Parse);
            /* Front End:
             * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
            */
            if (arrayBookIds.Length > 5)
            {
                return false;

            }
            return true;
        }

        public bool IsNumberOfTimesBRInMonthValid(BorrowingRequestDTO borrowingRequestDTO)
        {

            int[] arrayBookIds = Array.ConvertAll(borrowingRequestDTO.BorrowBooks.Split(','), Int32.Parse);
            /* Front End:
             * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
            */
            var numberOfBorrowRequestsInMonth = _repository.GetAllWithDetails().Count(br => br.UserId == borrowingRequestDTO.UserId && br.CreatedDate.Month == DateTime.Now.Month);
            if (numberOfBorrowRequestsInMonth >= 3)
            {
                return false;
            }
            return true;
        }
    }
}