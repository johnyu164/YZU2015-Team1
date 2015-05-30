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
            fi.ReadData("Library.txt");

            BookInformation info = fi.FindBookbyNumber("00001");
            Assert.AreEqual("", info.booknumber);
            Assert.AreEqual("", info.bookname);
            Assert.AreEqual("", info.borrowornot);
        }
    }
}
