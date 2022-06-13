using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEntityFramework.DAL;
using Microsoft.EntityFrameworkCore;

namespace HomeEntityFramework
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            using (var db = new AppContext())
            {
                var userRepository= new UserRepository(db);
                var bookRepos = new BookRepository(db);
                var user1 = new User { Name = "Arthur", Email = "Admin" };
                var user2 = new User { Name = "klim", Email = "User" };
                var user3 = new User { Name = "Apolo", Email = "Kurt" };
                var user4 = new User { Name = "Grom", Email = "Angl" };

                var book1 = new Book { BookName = "1", Autor = "1", Klass = "1", CreateDate = 1991 };
                var book2 = new Book { BookName = "2", Autor = "2", Klass = "2", CreateDate = 1992 };
                var book3 = new Book { BookName = "3", Autor = "3", Klass = "3", CreateDate = 1993 };
                var book4 = new Book { BookName = "4", Autor = "4", Klass = "4", CreateDate = 1994 };


                //Получение книги через юзера
                user1.Books.Add(book1);
                user2.Books.Add(book2);
                user3.Books.Add(book3);
                user4.Books.Add(book4);
                db.Books.AddRange(book1, book2, book3, book4);
                db.Users.AddRange(user1,user2, user3, user4);
                //получение книги при создании книги и закреплением за ним.
               

                Console.WriteLine("Получим список книг");
                var allbooks = bookRepos.SelectAllBooks();
                foreach(Book bokk in allbooks)
                {
                    Console.WriteLine(bokk);
                }
                Console.WriteLine("Введите ид книги");
                int idb = Convert.ToInt32(Console.ReadLine());
                var findByidbook = userRepository.SelectById(idb);
                foreach (Book bokk in allbooks)
                {
                    Console.WriteLine(bokk);
                }

                //проба вывести в таблице книги
                foreach (DataColumn column in allbooks)
                {
                    Console.Write($"{column.ColumnName}\t");
                }
                Console.WriteLine();
                
                foreach (DataRow row in allbooks)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        Console.Write($"{cell}\t");
                    }
                    Console.WriteLine();
                }
                
                db.SaveChanges();

                //Альтернативный способ удаления из БД записи.
               // db.Entry(user3).State = EntityState.Deleted; 

                // Выбор всех пользователей
               // var allUsersd = db.Users.ToList();

                // Выбор пользователей с ролью "Admin"
               // var admins = db.Users.Where(user => user.Email == "Admin").ToList();

                // Выбор первого пользователя в таблице
               // var firstuser = db.Users.FirstOrDefault();
                //присваивание нового майла
               // firstuser.Email = "1ralala@com";
                //db.SaveChanges();


          
                



               /*  С помощью полученных знаний дополните репозитории методами, которые позволят совершать следующие действия:

                 Получать список книг определенного жанра и вышедших между определенными годами.
                 Получать количество книг определенного автора в библиотеке.
                 Получать количество книг определенного жанра в библиотеке.
                 Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
                 Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
                 Получать количество книг на руках у пользователя.
                 Получение последней вышедшей книги.
                 Получение списка всех книг, отсортированного в алфавитном порядке по названию.
                 Получение списка всех книг, отсортированного в порядке убывания года их выхода.*/
            }
        }
    }
}
