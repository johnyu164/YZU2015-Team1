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
            Assert.AreEqual(true, Login.UserAuthentication("s1001555", "1234"));
            Assert.AreEqual(true, Login.UserAuthentication("s1001234", "abcd"));
            Assert.AreEqual(true, Login.UserAuthentication("s1009999", "88pp"));

            Assert.AreEqual(false, Login.UserAuthentication("s100asda", "asdasd"));
            Assert.AreEqual(false, Login.UserAuthentication("s13333da", "123fas"));
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
            Assert.AreEqual("003 00004 0602 0616", fi.findinformation("003"));
            Assert.AreEqual("002 00002 0605 0619", fi.findinformation("002"));
            Assert.AreEqual("001 00001 0601 0614", fi.findinformation("001"));
        }
        /*[TestMethod]
        public void ReturnBook_Load()
        {
            ReturnBook Rb = new ReturnBook();
            //Load the actual number 
            Assert.AreEqual("00002      書本B      1", Rb.Load_Number("00002"));
            Assert.AreEqual("00001      書本A      0", Rb.Load_Number("00001"));
<<<<<<< HEAD
            Assert.AreEqual("00003      書本C      0", Rb.Load_Number("00003"));

            Assert.AreEqual("No Find the Book !", Rb.Load_Number("00006"));

            //Can't actual return
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00001")));
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00003")));

            Assert.AreEqual("書本已歸還", Rb.Can_Return(Rb.Load_Number("00002")));

            Assert.AreEqual("沒在目錄中", Rb.Can_Return(Rb.Load_Number("000011")));
=======
        }*/

        [TestMethod]
        public void BorrowBook()
        {
            BorrowBook b = new BorrowBook();
            Assert.AreEqual("00001 書本A 作者a False", Convert.ToString(b.checkborrow("00001")));
            Assert.AreEqual("Error", Convert.ToString(b.checkborrow("00010")));

            Assert.AreEqual("Success borrow book 00001", Convert.ToString(b.Borrow("00001")));
            Assert.AreEqual("The book is borrowed!", Convert.ToString(b.Borrow("00002")));
            Assert.AreEqual("We don't have this book!", Convert.ToString(b.Borrow("00010")));
>>>>>>> 9b424494b3686ac5e50131cbb458add06fd5e6a5
        }
    }
}
