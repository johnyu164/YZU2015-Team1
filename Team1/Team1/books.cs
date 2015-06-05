using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
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

        public FindBook()
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
        

        public string FindBookbyNumber(String number)
        {
            string Sentence = "";
            for (int i = 0; i < 4; i++)
            {
                if (String.Compare(bookinformation[i].booknumber, number) == 0)
                {
                    Sentence = bookinformation[i].booknumber + " " + bookinformation[i].bookname + " " + bookinformation[i].writer + " " + bookinformation[i].borrowornot;
                }
            }

            return Sentence;
        }

        public int FindBookbyWriter(string WriterName)
        {

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

            int bookcount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (String.Compare(bookinformation[i].bookname, BookName, true) == 0)
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
}
