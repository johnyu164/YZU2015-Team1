using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    class BorrowBook
    {
        private string id;
        private string pwd;
        private string competence;
        private string borrowbooknumber;
        private FindBook f = new FindBook();
        
        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public bool borrowornot;
        };
        private BookInformation bookinformation = new BookInformation();
   

        public BorrowBook(string ID , string PWD, string num)
        {
            Login u = new Login(ID,PWD);
            id = u.getID();
            pwd = u.getpassword();
            competence = u.getcompetence();
            borrowbooknumber = u.getborrownumber();

        }

        public string Borrow(string booknumber)
        {            
            string Sentence = "";
            string borrowdate = DateTime.Now.ToShortDateString();
            string temp_borrowdate=DateTime.Now.ToString("yyyy-MM-dd");
            string returndate = "";
            String[] split = temp_borrowdate.Split('-');
            returndate = split[0] + "/" + split[1] + "/" + split[2];

            Sentence=f.FindBookbyNumber(booknumber);
            if (Sentence == "")
                Sentence = "We don't have this book!";
            else
            {
                Sentence = "";
                if (f.borrowbooks(booknumber))
                {
                    Sentence = "Success borrow book " + booknumber;

                    //寫檔
                }
                else if (!f.borrowbooks(booknumber))
                    Sentence = "The book is borrowed!";
            }
                    
            return Sentence;
        }
    }
}
