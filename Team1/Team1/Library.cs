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

    public class FindBook
    {
        struct BookInformation
        {
            public string booknumber;
            public string bookname;
            public string borrowornot;
        };

        BookInformation[] bookinformation = new BookInformation[3];

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
                    String[] Split = line.Split(' ');
                    bookinformation[Datacount - 1].booknumber = Split[0];
                    bookinformation[Datacount - 1].bookname = Split[6];
                    bookinformation[Datacount - 1].borrowornot = Split[12];
                    
                    Datacount++;
                }
            }

            string Sentence="";
            for (int i = 0; i < 3; i++)
            {
                if (String.Compare(bookinformation[i].booknumber, number) == 0)
                {
                    Sentence = bookinformation[i].booknumber+bookinformation[i].bookname+bookinformation[i].borrowornot;
                }
            }

            return Sentence;
        }
        private bool CheckBorroworNot(int borrowornot)
        {
            if (borrowornot == 0)
                return true;
            else
                return false;
        }
    }
}
