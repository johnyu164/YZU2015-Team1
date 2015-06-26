using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team1
{
    public class Search
    {

         struct bookinformation
        {
            public string booknumber;
            public string bookname;
            public string writer;
            public string ifborrow;
            public string borrowdate;
            public string returndate;
        };

        bookinformation[] bookinfo = new bookinformation[50];
        int count;
        int resultcount;

        public Search()
        {
            count = 0;
            resultcount = 0;

            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String str;

            while ((str = sr.ReadLine()) != null)
            {
                if (count == 0)
                {
                    count++;
                }
                else
                {
                    String[] split = str.Split(' ');
                    bookinfo[count - 1].booknumber = split[0];
                    bookinfo[count - 1].bookname = split[1];
                    bookinfo[count - 1].writer = split[2];
                    bookinfo[count - 1].ifborrow = split[3];
                    bookinfo[count - 1].borrowdate = split[4];
                    bookinfo[count - 1].returndate = split[5];
                }
                count++;
            }
            count--;
            sr.Close();

        }


        public string Search_by_Keyword(string keyword, string[] searchresult)
        {
            string response = "";
           
            for (int i = 1; i < count; i++)
            {
                if (bookinfo[i].booknumber == keyword || bookinfo[i].bookname.Contains(keyword) || bookinfo[i].writer.Contains(keyword))
                {
                    searchresult[resultcount] = bookinfo[i].booknumber + " " + bookinfo[i].bookname + " " + bookinfo[i].writer;
                    if (bookinfo[i].ifborrow == "0")
                        searchresult[resultcount] += " 在架上";
                    else
                        searchresult[resultcount] += (" 借出中 應還日期" + bookinfo[i].returndate);
                      
                    resultcount++;
                }

                if (i == (count - 1) && resultcount == 0)
                    response = "找不到符合搜尋字詞的書籍。";
                else if (i == (count - 1))
                    response = "搜尋結果為 " + resultcount.ToString() + " 筆。";
            }

            resultcount = 0;
            return response;
        }
    }
}
