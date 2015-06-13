using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    class ReturnBook
    {
        private string ReturnBook_number;
        public string Load_Number_for_Library(String number)
        {
            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[0] == number)
                {
                    return Split[0] + " " + Split[1] + " " + Split[2] + " " + Split[3] + " " + Split[4] + " " + Split[5];
                }         
            }
            return "No Book Found!";    
        }

        public string Load_Number_for_borrow(String number)
        {
            StreamReader sr = new StreamReader("..\\..\\borrow.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[1] == number)
                {
                    return Split[0];

                    //改檔 borrow.txt 把後面日期給消掉
                }
            }
            return "No Book Found!";
        }

        public string getUser_for_ReturnBook(String account)
        {
            StreamReader sr = new StreamReader("..\\..\\User.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[0] == account)
                {
                    //改檔 User.txt 把書本數目更改，書單更改
                    return Split[0] + "書本已歸還";
                }
            }
            return "No Book Found!";
        }



        public string Can_Return(String borrowornot)
        {
            String[] Split = borrowornot.Split(' ');
            try
            {
                if (Split[3] == "1")
                {
                    DateTime ReturnTime, ShouldReturnTime;
                    ReturnTime = Convert.ToDateTime(Split[4]);
                    ShouldReturnTime = Convert.ToDateTime(Split[5]);

                    if (DateTime.Compare(ShouldReturnTime, ReturnTime) >= 0)
                        return "書本已歸還";
                    else
                    {
                        TimeSpan Total = ReturnTime.Subtract(ShouldReturnTime);
                        int Fines = Convert.ToInt32(Total.Days) * 50;
                        string ReturnString = "逾期" + Total.Days.ToString() + "天,要繳交罰鍰" + Fines.ToString() + "元";
                        return ReturnString;
                    }
                }
                else if (Split[3] == "0")
                    return "書本未被借出，無法歸還!!"; 
            }
            catch (System.IndexOutOfRangeException)
            {
                return "沒在目錄中";
            }

            return "沒在目錄中";
        }
    }
}
