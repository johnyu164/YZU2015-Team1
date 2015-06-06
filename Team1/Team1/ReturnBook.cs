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
        public string Load_Number(String number)
        {
            StreamReader sr = new StreamReader("Library.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] Split = line.Split(' ');
                if (Split[0] == number)
                {
                    return Split[0] + " " + Split[1] + " " + Split[2] + " " + Split[3];
                }         
            }
            return "No Find the Book !";    
        }

        public string Can_Return(String borrowornot)
        {
            String[] Split = borrowornot.Split(' ');
            if (Split[3] == "1")
                return "書本已歸還";
            else if (Split[3] == "0")
                return "書本未被借出，無法歸還!!";

            return "沒在目錄中";
        }
    }
}
