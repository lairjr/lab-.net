using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T2.Tests
{
    [TestClass]
    public class SearchTests
    {
        private NumberGraph graph;

        [TestInitialize]
        public void Setup()
        {
            this.graph = new NumberGraph();
        }

        [TestMethod]
        public void SampleTest()
        {
            var numbers = new int[] { 782, 229, 446, 527, 874, 19, 829, 70, 830, 992, 430, 649 };

            foreach (var num in numbers)
            {
                var basedNumber = BasedNumber.Parse(num, 6);
                graph.Insert(basedNumber);
            }

            var result = graph.GetBiggestPath().ToList();

            Assert.AreEqual(result[0].Value, "3001");
            Assert.AreEqual(result[1].Value, "3501");
            Assert.AreEqual(result[2].Value, "3502");
        }

        [TestMethod]
        public void SampleTest_MultiplePath()
        {
            var numbers = new int[] { 396, 221, 401, 233, 569, 413, 419, 617, 833, 845, 216 };

            foreach (var num in numbers)
            {
                var basedNumber = BasedNumber.Parse(num, 6);
                graph.Insert(basedNumber);
            }

            var result = graph.GetBiggestPath().ToList();

            Assert.AreEqual(result[0].Value, "1000");
            Assert.IsTrue(result[1].Value == "1005" || result[1].Value == "1500");
            Assert.AreEqual(result[2].Value, "1505");
            Assert.AreEqual(result[3].Value, "2505");
            Assert.AreEqual(result[4].Value, "3505");
            Assert.AreEqual(result[5].Value, "3525");
        }

        [TestMethod]
        public void SampleTest_MultiplePathDiferentCountNumber()
        {
            var numbers = new int[] { 552, 415, 558, 559, 7032, 22584, 631, 1848 };

            foreach (var num in numbers)
            {
                var basedNumber = BasedNumber.Parse(num, 6);
                graph.Insert(basedNumber);
            }

            var result = graph.GetBiggestPath().ToList();

            Assert.AreEqual(result[0].Value, "2320");
            Assert.AreEqual(result[1].Value, "2330");
            Assert.AreEqual(result[2].Value, "2331");
        }

        [TestMethod]
        public void SampleTest_MultiplePathDiferent2()
        {
            var numbers = new BasedNumber[] { 
                new BasedNumber("1531", 6),
                new BasedNumber("2531", 6),
                new BasedNumber("3631", 6),
                new BasedNumber("2541", 6),
                new BasedNumber("2535", 6),
                new BasedNumber("3531", 6),
                new BasedNumber("2332", 6),
                new BasedNumber("2331", 6),
                new BasedNumber("2330", 6),
                new BasedNumber("2320", 6)
            };

            foreach (var num in numbers)
            {
                graph.Insert(num);
            }

            var result = graph.GetBiggestPath().ToList();

            Assert.AreEqual(result[0].Value, "2320");
            Assert.AreEqual(result[1].Value, "2330");
            Assert.AreEqual(result[2].Value, "2331");
            Assert.AreEqual(result[3].Value, "2531");
            Assert.AreEqual(result[4].Value, "3531");
            Assert.AreEqual(result[5].Value, "3631");
        }
    }
}
