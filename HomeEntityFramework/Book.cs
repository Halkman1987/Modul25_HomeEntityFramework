using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEntityFramework
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int CreateDate { get; set; }

        public string Autor { get; set; }
        public string Klass { get; set; }

        public User User;  /* => new User();*/
    }
}
