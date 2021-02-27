using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MinesweeperTests
{
    [TestClass]
    public class UnitTest1
    {
        private string Expected = String.Join(
            Environment.NewLine,
            "Field #1:",
            "*100",
            "2210",
            "1*10",
            "1110",
            "",
            "Field #2:",
            "**100",
            "33200",
            "1*100");


        [TestMethod]
        public void TestMethod1()
        {
            string boardsFile = String.Join(
                Environment.NewLine,
                "4 4",
                "*...",
                "....",
                ".*..",
                "....",
                "3 5",
                "**...",
                ".....",
                ".*...",
                "0 0");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Minesweeper.Program.GenerateBoard(boardsFile);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }


        }
    }
}
