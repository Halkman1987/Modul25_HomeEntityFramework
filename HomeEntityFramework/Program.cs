using System;
using System.Collections.Generic;
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
                /* book3.User = user3;
                 book4.User = user4;*/

                Console.WriteLine("Получим список книг");
                var allbooks = bookRepos.SelectAllBooks();
                foreach(Book bokk in allbooks)
                {
                    Console.WriteLine(bokk);
                }
                Console.WriteLine("Введите ид книги");
                int idb = Convert.ToInt32(Console.ReadLine());
                userRepository.SelectById(idb);
                /*db.Users.Add(user1);
                db.Users.AddRange(user2, user3, user4);
               */
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


                /* Для каждой из моделей в приложении создайте собственный класс - репозиторий(например, UserRepository и BookRepository),
                *  в которых опишите следующие действия: 
                *  1 выбор объекта из БД по его идентификатору, 
                *  2 выбор всех объектов,
                *  3 добавление объекта в БД и
                *  4 его удаление из БД.
                *     А также специфичные методы: 
                *      обновление имени пользователя(по Id) и 
                *      обновление года выпуска книги(по Id).
                
                Пришло время расширить проект и добавить в него некоторые новые части. 
                Реализуйте с помощью одной из связей возможность получения книги «на руки» пользователем 
                (для этого придется удалить таблицы из БД, либо воспользоваться EnsureDeleted). 
                А также придумайте, как можно добавить в книгу автора и жанр книги.
                



                 С помощью полученных знаний дополните репозитории методами, которые позволят совершать следующие действия:

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
