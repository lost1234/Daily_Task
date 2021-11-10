using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinEditDistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinEditDistance.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void minDistaceTest()
        {
            string s1 = "xyzab";
            string s2 = "axyzc";
            string expected = "The distance is 3";
            int distance = Program.minDistance(s1, s2);
            string result = "The distance is " + distance.ToString();
            Assert.AreEqual(expected, result) ;
        }
    }
}