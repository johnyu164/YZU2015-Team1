using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    class Library
    {
        //static void Main()
        //{
        //    FindBook fi = new FindBook();
        //    fi.ReadData("Library.txt");

        //    System.Console.WriteLine("請輸入書本編號:");
        //    string BookNumber = Console.ReadLine();

        //    fi.FindBookbyNumber(BookNumber);

        //    Console.Read();
        //}

        
    }
    class Login
    {
        static internal bool UserAuthentication(String id, String pwd)
        {
            bool accountExist = false;

            char[] delimiters = new char[] { '\t', ' ' };
            StreamReader sr = new StreamReader("User.txt", Encoding.Default);
            while (!sr.EndOfStream) // 每次讀取一行，直到檔尾            
            {
                string line = sr.ReadLine();    // 讀取文字到 line 變數
                string[] item = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (item[0].Equals(id))
                {
                    if (item[1].Equals(pwd))
                    {
                        accountExist = true;
                        break;
                    }
                }
            }
            sr.Close();

            return accountExist;
        }
    }


    public class FindBook
    {
        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public string borrowornot;
        };

        BookInformation[] bookinformation = new BookInformation[4];





        public string FindBookbyNumber(String number)
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
                    bookinformation[Datacount - 1].borrowornot = split[3];
                    
                    Datacount++;
                }
            }

            string Sentence="";
            for (int i = 0; i < 4; i++)
            {
                if (String.Compare(bookinformation[i].booknumber, number) == 0)
                {
                    Sentence = bookinformation[i].booknumber+" "+bookinformation[i].bookname+" "+ bookinformation[i].writer+" "+ bookinformation[i].borrowornot;
                }
            }

            return Sentence;
        }

        public int FindBookbyWriter(string WriterName)
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
                    bookinformation[Datacount - 1].borrowornot = split[3];

                    Datacount++;
                }
            }

            int bookcount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (String.Compare(bookinformation[i].writer, WriterName, true) == 0)
                {
                    bookcount++;
                }
            }

            return bookcount;
        }

        public int FindBookbyBookname(string BookName)
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
                    bookinformation[Datacount - 1].borrowornot = split[3];

                    Datacount++;
                }
            }

            int bookcount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (String.Compare(bookinformation[i].bookname, BookName,true) == 0)
                {
                    bookcount++;
                }
            }

            return bookcount;
        }

        private bool CheckBorroworNot(int borrowornot)
        {
            if (borrowornot == 0)
                return true;
            else
                return false;
        }
    }

    class BorrowInfo
    {
        internal static string Convert(int number)
        {

            StreamReader sr = new StreamReader("borrow.txt", Encoding.Default);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line.ToString());
            }

            return "001";
        }
    }


    class BorrowBook
    {

        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public string borrowornot;
        };
        private BookInformation[] bookinformation = new BookInformation[4];

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
                    bookinformation[Datacount - 1].borrowornot = split[3];

                    Datacount++;
                }
            }
        }

        public string checkborrow(string booknumber)
        {
            readInfomation();

            string Sentence="";
            for(int i=0 ; i<4 ; i++)
            {
                if (bookinformation[i].booknumber == booknumber)
                    Sentence = bookinformation[i].booknumber+" "+bookinformation[i].bookname+" "+ bookinformation[i].writer+" "+ bookinformation[i].borrowornot;
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
                if (bookinformation[i].booknumber == booknumber && bookinformation[i].borrowornot=="0")
                {
                    bookinformation[i].borrowornot = "1";
                    Sentence= "Success borrow book " + booknumber;
                }
                else if (bookinformation[i].booknumber == booknumber && bookinformation[i].borrowornot == "1")
                {
                    Sentence = "The book is borrowed!" ;
                }
            }

            if (Sentence=="")
                Sentence = "We don't have this book!";
            return Sentence;
        }
    }
    
}
