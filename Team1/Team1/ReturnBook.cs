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
        string local_data;
        public string Load_Number_for_Library(String number)
        {
            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String line, data;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[0] == number)
                {
                    data = Split[0] + " " + Split[1] + " " + Split[2] + " " + Split[3] + " " + Split[4] + " " + Split[5];      
                    return data;
                }         
            }
            sr.Close();
            return "No Book Found!";    
        }

        //Return book, so we need to change the data in Library.txt. 借書時間與應還時間改為"0"
        public string Fixed_the_time_of_borrow_and_return(String data)
        {
            String[] Split = data.Split(' ');
            if (Split[3]=="1")
            {
                StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
                String str = sr.ReadToEnd();
                str = str.Replace(data, Split[0] + " " + Split[1] + " " + Split[2] + " " + "0 0 0");
                sr.Close();
                StreamWriter sw = new StreamWriter("..\\..\\Library_temp.txt");
                sw.WriteLine(str);
                sw.Close();
                return "Do return in library.txt";
            }
            return "書本未被借出，無法歸還!!";
        }

        //Return book, so we need to change the data in history.txt. 新增借還書紀錄
       /* public string Fixed_the_history_of_borrow_and_return(String data)
        {
            String[] Split = data.Split(' ');
            //StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            //String str = sr.ReadToEnd();
            //str = str.Replace(data, Split[0] + " " + Split[1] + " " + Split[2] + " " + "0 0 0");
            //sr.Close();
            StreamWriter sw = new StreamWriter("..\\..\\Library_temp.txt");
            sw.WriteLine(str);
            sw.Close();
            return "Do return in history.txt";
        }*/

        public string Load_Number_for_borrow(String number)
        {
            StreamReader sr = new StreamReader("..\\..\\history.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[1] == number)
                {
                    return Split[0];

                    //改檔 history.txt 把後面日期給消掉
                }
            }
            sr.Close();
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
            sr.Close();
            return "No Book Found!";
        }

        public string CanReturnInSpecificDate(String borrowornot, DateTime now)
        {
            String[] split = borrowornot.Split(' ');
            try
            {
                if (split[3] == "1")
                {
                    DateTime shouldReturnTime;
                    shouldReturnTime = Convert.ToDateTime(split[5]);

                    if (DateTime.Compare(shouldReturnTime, now) >= 0)
                        return "書本尚未逾期";
                    else
                    {
                        TimeSpan total = now.Subtract(shouldReturnTime);
                        int Fines = Convert.ToInt32(total.Days) * 50;
                        string ReturnString = "逾期" + total.Days.ToString() + "天,要繳交罰鍰" + Fines.ToString() + "元";
                        return ReturnString;
                    }
                }
                else if (split[3] == "0")
                    return "書本未被借出，無法歸還!!";
            }
            catch (System.IndexOutOfRangeException)
            {
                return "沒在目錄中";
            }

            return "沒在目錄中";

        }

        public string Can_Return(String borrowornot)
        {
            return CanReturnInSpecificDate(borrowornot, DateTime.Now);
        }
    }
}
