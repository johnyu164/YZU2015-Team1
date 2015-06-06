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

        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public bool borrowornot;
        };
        private BookInformation[] bookinformation = new BookInformation[5];
   

        public void readInfomation()
        {
            StreamReader sr = new StreamReader("Library.txt", Encoding.Default);
            String line;
            int Datacount = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (Datacount == 0)
                {
                    Datacount++;
                }
                else
                {
                    String[] split = line.Split(' ');
                    bookinformation[Datacount - 1].booknumber = split[0];
                    bookinformation[Datacount - 1].bookname = split[1];
                    bookinformation[Datacount - 1].writer = split[2];
                    if (split[3] == "0")
                        bookinformation[Datacount - 1].borrowornot = false;
                    else
                        bookinformation[Datacount - 1].borrowornot = true;

                    Datacount++;
                }
            }
        }

        public string checkborrow(string booknumber)
        {
            readInfomation();

            string Sentence = "";
            for (int i = 0; i < 4; i++)
            {
                if (bookinformation[i].booknumber == booknumber)
                    Sentence = bookinformation[i].booknumber + " " + bookinformation[i].bookname + " " + bookinformation[i].writer + " " + bookinformation[i].borrowornot;
            }

            if (Sentence == "")
                Sentence = "Error";
            return Sentence;
        }

        public string Borrow(string booknumber)
        {
            readInfomation();
            string Sentence = "";
            for (int i = 0; i < 4; i++)
            {
                if (bookinformation[i].booknumber == booknumber )
                {
                    if (!bookinformation[i].borrowornot) { 
                        bookinformation[i].borrowornot = true;
                        Sentence = "Success borrow book " + booknumber;
                    }

                    else if (bookinformation[i].borrowornot)
                    
                        Sentence = "The book is borrowed!";
                    
                }
            }

            if (Sentence == "")
                Sentence = "We don't have this book!";
            return Sentence;
        }
    }
}
