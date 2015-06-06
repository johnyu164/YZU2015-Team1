using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Team1
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]
        public void FindBookbyNumber()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("00001書本A作者a0",fi.FindBookbyNumber("00001"));
        }

        [TestMethod]
        public void FindBookbyWriter()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("2", Convert.ToString(fi.FindBookbyWriter("作者a")));
            Assert.AreEqual("0", Convert.ToString(fi.FindBookbyWriter("作者b")));
        }

        [TestMethod]
        public void FindBookbyBookname()
        {
            FindBook fi = new FindBook();
            Assert.AreEqual("2", Convert.ToString(fi.FindBookbyBookname("書本C")));
            Assert.AreEqual("0", Convert.ToString(fi.FindBookbyBookname("書本D")));
        }

        [TestMethod]
        public void BookBorrowInfo()
        {
            Assert.AreEqual("001", BorrowInfo.Convert(1));
        }
        [TestMethod]
        public void ReturnBook_Load()
        {
            ReturnBook Rb = new ReturnBook();
            //Load the actual number 
            Assert.AreEqual("00002      書本B      1", Rb.Load_Number("00002"));
            Assert.AreEqual("00001      書本A      0", Rb.Load_Number("00001"));
            Assert.AreEqual("00003      書本C      0", Rb.Load_Number("00003"));

            Assert.AreEqual("No Find the Book !", Rb.Load_Number("00006"));

            //Can't actual return
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00001")));
            Assert.AreEqual("書本未被借出，無法歸還!!", Rb.Can_Return(Rb.Load_Number("00003")));

            Assert.AreEqual("書本已歸還", Rb.Can_Return(Rb.Load_Number("00002")));

            Assert.AreEqual("沒在目錄中", Rb.Can_Return(Rb.Load_Number("000011")));
        }
    }
}
