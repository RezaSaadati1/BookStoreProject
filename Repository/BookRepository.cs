using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookDetailsDto>> GetAllBooks()
        {
            var books = await _context.Books.Select(x => new BookDetailsDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Amount = x.Amount
            }).ToListAsync();
            return books;

        }

        public async Task<BookDetailsDto> GetBookDetailsById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                            .Select(x => new BookDetailsDto
                                            {
                                                Id = x.Id,
                                                Title = x.Title,
                                                Description = x.Description,
                                                Amount = x.Amount
                                            }).FirstOrDefaultAsync();
            return book;
        }

        public async Task<int> CreateBook(CreateBookDto model)
        {
            var book = new Book()
            {
                Amount = model.Amount,
                Description = model.Description,
                Title = model.Title
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Amount = model.Amount;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveBook(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}