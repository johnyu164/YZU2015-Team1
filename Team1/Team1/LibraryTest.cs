using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Team1
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]

        public void Login_Test()
        {
            Login test1 = new Login();
            test1.FindAccount("s1001555", "1234");
            Assert.AreEqual(true, test1.UserAuthentication());

            Login test2 = new Login();
            test2.FindAccount("s1001234", "abcd");

            Assert.AreEqual(true, test2.UserAuthentication());
            Login test3 = new Login(); 
            test3.FindAccount("s1009999", "88pp");
            Assert.AreEqual(true,test3.UserAuthentication());

            Login test4 = new Login();
            test4.FindAccount("s100asda", "asdasd");
            Assert.AreEqual(false, test4.UserAuthentication());

            Login test5 = new Login(); 
            test5.FindAccount("s1001555", "5678");
            Assert.AreEqual(false, test5.UserAuthentication());
        }

        [TestMethod]

        public void FindBookbyNumber()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("00001 書本A 作者a", fi.FindBookbyNumber("00001"));
        }

        [TestMethod]
        public void FindBookbyWriter()
        {
            FindBook fi = new FindBook();
            int[] booknum = new int[20];
            fi.FindBookbyWriter("作者a", booknum);
            Assert.AreEqual(0, booknum[0]);
            Assert.AreEqual(4, booknum[1]);
            fi.FindBookbyWriter("作者b", booknum);
            Assert.AreEqual(1, booknum[0]);
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            int[] booknum = new int[20];
            fi.FindBookbyBookname("書本C", booknum);
            Assert.AreEqual(2, booknum[0]);
            Assert.AreEqual(3, booknum[1]);
        }

        [TestMethod]
        public void BookBorrowInfo()
        {
            BorrowInfo fi = new BorrowInfo();
            Assert.AreEqual("003 00004", fi.findinformation("003"));
            Assert.AreEqual("002 00002", fi.findinformation("002"));
            Assert.AreEqual("001 00001", fi.findinformation("001"));
        }
        [TestMethod]
        public void ReturnBook_Load()
        {
            ReturnBook Rb = new ReturnBook();
            //Load the actual number 
            Assert.AreEqual("00002 書本B 作者b 1 2015/6/6 2015/7/6", Rb.Load_Number("00002"));
            Assert.AreEqual("00001 書本A 作者a 0 0 0", Rb.Load_Number("00001"));
            Assert.AreEqual("00003 書本C 作者c 0 0 0", Rb.Load_Number("00003"));
            Assert.AreEqual("00003 書本C 作者c 0 0 0", Rb.Load_Number("00003"));
            Assert.AreEqual("00004 書本C 作者c 1 2015/7/7 2015/8/7", Rb.Load_Number("00004"));


            Assert.AreEqual("No Book Found!", Rb.Load_Number("00010"));

            //Can't actual return
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00001")));
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00003")));

            Assert.AreEqual("書本已歸還", Rb.Can_Return(Rb.Load_Number("00002")));

            Assert.AreEqual("沒在目錄中", Rb.Can_Return(Rb.Load_Number("00011")));

            Assert.AreEqual("書本已歸還", Rb.Can_Return(Rb.Load_Number("00002")));
            Assert.AreEqual("逾期1天,要繳交罰鍰50元", Rb.Can_Return(Rb.Load_Number("00006")));
                
        }

        [TestMethod]
        public void BorrowBook()
        {
            Login test1 = new Login();
            test1.FindAccount("s1001555", "1234");
            BorrowBook b = new BorrowBook(test1.getID(), test1.getpassword(), "00001");

            //Assert.AreEqual("00001 書本A 作者a False", Convert.ToString(b.checkborrow("00001")));
            //Assert.AreEqual("Error", Convert.ToString(b.checkborrow("00010")));

            Assert.AreEqual("Success borrow book 00001", Convert.ToString(b.Borrow("00001")));
            Assert.AreEqual("The book is borrowed!", Convert.ToString(b.Borrow("00002")));
            Assert.AreEqual("We don't have this book!", Convert.ToString(b.Borrow("00010")));
        }
    }
}
