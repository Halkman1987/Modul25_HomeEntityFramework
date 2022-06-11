using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEntityFramework.DAL
{
    public class BookRepository
    {
        public AppContext db;

        public BookRepository(AppContext db)
        {
            this.db = db;
        }

        public Book SelectById(int id)
        {
            var bookId = db.Books.Find(id);
            return bookId;
        }
        public List<Book> SelectAllBooks()
        {
            var allUsersd = db.Books.ToList();
            return allUsersd;

        }
        public void DeleteUserById(int idBook)
        {
            var book = SelectById(idBook);
            var delBook = db.Books.Remove(book);
            db.SaveChanges();
        }
        public void AddNewUser(Book book) //передаем сразу сущность юзера
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public void UpdateBookCreateYear(int IdBook, int newDate)
        {
            var userId = db.Books.Find(IdBook);
            userId.CreateDate = newDate;
            db.SaveChanges();
        }

    }
}
