using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
        Task<BookDetailsDto> GetBookDetailsById(int id);
        Task<int> CreateBook(CreateBookDto model);
        Task<bool> UpdateBook(int id, UpdateBookDto model);
        Task<bool> RemoveBook(int id);
    }
}