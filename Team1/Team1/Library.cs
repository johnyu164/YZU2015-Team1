using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    struct BookInformation
    {
        public string booknumber;
        public string bookname;
        public string borrowornot;
    };


    class Library
    {
        static void Main()
        {
            FindBook fi = new FindBook();
            fi.ReadData("Library.txt");

            System.Console.WriteLine("請輸入書本編號:");
            string BookNumber = Console.ReadLine();

            fi.FindBookbyNumber(BookNumber);

            Console.Read();
        }

        
    }

    public class FindBook
    {
        BookInformation[] bookinformation = new BookInformation[3];

        public void ReadData(String path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
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
                    StoreData(Datacount, line);
                    Datacount++;
                }
            }
        }

        private void StoreData(int Datacount ,String information)
        {
            String[] Split = information.Split(' ');
            bookinformation[Datacount - 1].booknumber = Split[0];
            bookinformation[Datacount - 1].bookname = Split[6];
            bookinformation[Datacount - 1].borrowornot = Split[12];
        }

        public void FindBookbyNumber(string number)
        {
            for (int i = 0; i < 3; i++)
            {
                if (String.Compare(bookinformation[i].booknumber, number) == 0)
                {
                    int borrowornot = Convert.ToInt32(bookinformation[i].borrowornot);
                    if (CheckBorroworNot(borrowornot))
                    {
                        String Output = "書本編號:" + bookinformation[i].booknumber + " 書名:" + bookinformation[i].bookname + " 狀態:未借出";
                        Console.WriteLine(Output);
                    }
                    else
                    {
                        String Output = "書本編號:" + bookinformation[i].booknumber + " 書名:" + bookinformation[i].bookname + " 狀態:已借出";
                        Console.WriteLine(Output);
                    }
                }
            }
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
