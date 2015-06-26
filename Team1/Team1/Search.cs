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
        int info_amount;
        int result_amount;

        public Search()
        {
            info_amount = 0;
            result_amount = 0;

            StreamReader sr = new StreamReader("..\\..\\Library.txt", Encoding.Default);
            String str;

            while ((str = sr.ReadLine()) != null)
            {
                if (info_amount == 0)
                {
                    info_amount++;
                }
                else
                {
                    String[] split = str.Split(' ');
                    bookinfo[info_amount - 1].booknumber = split[0];
                    bookinfo[info_amount - 1].bookname = split[1];
                    bookinfo[info_amount - 1].writer = split[2];
                    bookinfo[info_amount - 1].ifborrow = split[3];
                    bookinfo[info_amount - 1].borrowdate = split[4];
                    bookinfo[info_amount - 1].returndate = split[5];
                }
                info_amount++;
            }
            info_amount--;
            sr.Close();

        }


        public string Search_by_Keyword(string keyword, string[] searchresult)
        {
            string response = "";
           
            for (int i = 1; i < info_amount; i++)
            {
                if (bookinfo[i].booknumber == keyword || bookinfo[i].bookname.Contains(keyword) || bookinfo[i].writer.Contains(keyword))
                {
                    searchresult[result_amount] = bookinfo[i].booknumber + " " + bookinfo[i].bookname + " " + bookinfo[i].writer;
                    if (bookinfo[i].ifborrow == "0")
                        searchresult[result_amount] += " 在架上";
                    else
                        searchresult[result_amount] += (" 借出中 應還日期" + bookinfo[i].returndate);
                      
                    result_amount++;
                }

                if (i == (info_amount - 1) && result_amount == 0)
                    response = "找不到符合搜尋字詞的書籍。";
                else if (i == (info_amount - 1))
                    response = "搜尋結果為 " + result_amount.ToString() + " 筆。";
            }

            result_amount = 0;
            return response;
        }
    }
}
