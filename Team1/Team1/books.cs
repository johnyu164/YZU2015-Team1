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
            public bool borrowornot;
            //public DateTime RealReturnDate;
           // public DateTime ShouldReturnDate;

        };

        private BookInformation[] bookinformation = new BookInformation[20];
        int Datacount = 0;
        public FindBook()
        {
            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String line;
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
                        bookinformation[Datacount - 1].borrowornot = true;
                    else
                        bookinformation[Datacount - 1].borrowornot = false;

                    String[] splitdate1 = split[4].Split('/');
                    String[] splitdate2 = split[4].Split('/');
                    
                   /* bookinformation[Datacount - 1].RealReturnDate.AddYears(Convert.ToInt32(splitdate1[0]));
                    bookinformation[Datacount - 1].RealReturnDate.AddMonths(Convert.ToInt32(splitdate1[1]));
                    bookinformation[Datacount - 1].RealReturnDate.AddDays(Convert.ToInt32(splitdate1[2]));

                    bookinformation[Datacount - 1].ShouldReturnDate.AddYears(Convert.ToInt32(splitdate2[0]));
                    bookinformation[Datacount - 1].ShouldReturnDate.AddMonths(Convert.ToInt32(splitdate2[1]));
                    bookinformation[Datacount - 1].ShouldReturnDate.AddDays(Convert.ToInt32(splitdate2[2]));
                    */
                    Datacount++;
                }
            }
            Datacount--;//修正最後一次while
            sr.Close();
        }


        public string FindBookbyNumber(String number)
        {
            string Sentence = "";
            for (int i = 0; i < Datacount; i++)
            {
                if (String.Compare(bookinformation[i].booknumber, number , true) == 0)
                {
                    Sentence = bookinformation[i].booknumber + " " + bookinformation[i].bookname + " " + bookinformation[i].writer;
                }
            }

            return Sentence;
        }

        public void FindBookbyWriter(string WriterName, int[] bookarr)
        {

            int bookcount = 0;
            for (int i = 0; i < Datacount; i++)
            {
                if (String.Compare(bookinformation[i].writer, WriterName) == 0)
                {
                    bookarr[bookcount] = i;
                    bookcount++;
                }
            }
            bookarr[bookcount] = -1;//array 在-1結束 
        }

        public void FindBookbyBookname(string BookName, int[] bookarr)
        {
            int bookcount = 0;
            for (int i = 0; i < Datacount; i++)
            {
                if (String.Compare(bookinformation[i].bookname, BookName, true) == 0)
                {
                    bookarr[bookcount] = i;
                    bookcount++;
                }
            }
            bookarr[bookcount] = -1;
        }

        public bool borrowbooks(string booknum)
        {
            for (int i = 0; i < 20; i++)
            {
                if (bookinformation[i].booknumber == booknum)
                {
                    if (bookinformation[i].borrowornot)
                        return true;
                    if (!bookinformation[i].borrowornot)
                        return false;
                }
            }

            return false;
        }


    }
}
