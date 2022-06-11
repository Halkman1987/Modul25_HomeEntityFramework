using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEntityFramework.DAL
{
    public class UserRepository
    {
        public AppContext db;
        public UserRepository(AppContext db)
        {
            this.db = db;
        }

        public User SelectById(int id)
        {
            var userId = db.Users.Find(id);
           /* var users = (from user in db.Users
                         where user.Id == id
                         select user).ToList();*/
            return userId;
        }
        public List<User> SelectAllUser()
        {
            var allUsersd = db.Users.ToList();
            return allUsersd;

        }
        public void DeleteUserById(int iduser)
        {
            var user = SelectById(iduser);
            var delUser = db.Users.Remove(user);
            db.SaveChanges();
        }
        public void AddNewUser(User user) //передаем сразу сущность юзера
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
       
        
        //обращение через осн меню, сюда передаем только параметры без консольного вмешательства
        // только Id юзера и новое имя ему
        public void UpdateUserName(int Iduser, string nameUser) 
        {
            //поиск через файнд 
            var userId = db.Users.Find(Iduser);
            userId.Name = nameUser;
            db.SaveChanges();
        }

       
    }
}
