using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiLibraryManagement.Models;
using WebApiLibraryManagement.Repositories;

namespace WebApiLibraryManagement.Services
{
    public class BorrowingRequestServices : IBorrowingRequestServices

    {
        private readonly IBorrowingRequestRepository _repository;
        private readonly IBorrowingRequestDetailsRepository _bDRepository;
        public BorrowingRequestServices(IBorrowingRequestRepository repository, IBorrowingRequestDetailsRepository bDRepository)
        {
            _repository = repository;
            _bDRepository = bDRepository;
        }

        public int[] arrayBookIds(BorrowingRequestDTO borrowingRequestDTO)
        {
            return Array.ConvertAll(borrowingRequestDTO.BorrowBooks.Split(','), Int32.Parse);
            /* Front End:
             * string borrowingBooksRequestArrayToString = String.Join(",", borrowingBooksRequestArrayToString.Select(p => p.ToString()).ToArray());
            */
        }

        public bool IsNumberOfTimesBRInMonthValid(BorrowingRequestDTO borrowingRequestDTO)
        {

            int numberOfBorrowRequestsInMonth = _repository.GetAllWithDetails().Count(br => br.UserId == borrowingRequestDTO.UserId && br.CreatedDate.Month == DateTime.Now.Month);
            if (numberOfBorrowRequestsInMonth >= 3)
            {
                return false;
            }
            return true;
        }

        public bool IsBRInABRValid(int[] arrayBookIds, BorrowingRequestDTO borrowingRequestDTO)
        {
            if (arrayBookIds.Length > 5)
            {
                return false;

            }
            return true;
        }

        public BorrowingRequest CreateBorrowingRequest(int[] arrayBookIds, BorrowingRequestDTO borrowingRequestDTO)
        {

            var entity = new BorrowingRequest
            {
                UserId = borrowingRequestDTO.UserId,
                Status = "Waiting",
                CreatedDate = DateTime.Now
            };

            _repository.Insert(entity);
            return entity;
        }

        public void CreateBorrowingRequestDetails(int bRId, int[] arrayBookIds)
        {
            foreach (int bookId in arrayBookIds)
            {
                var entityRequestDetails = new BorrowingRequestDetail
                {
                    BookId = bookId,
                    BorrowingRequestId = bRId,
                };
                _bDRepository.Insert(entityRequestDetails);
            }
        }
    }
}