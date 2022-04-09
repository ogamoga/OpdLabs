using firstTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace firstTaskTest {
    [TestClass]
    public class UnitTests {

        [TestMethod]
        public void increasingBySum() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.bySum);
            sorter.sort(data, true);

            int[][] expected = {
                new[] { 4, 40,  200},
                new[] { 1, 30,  300 },
                new[] { 2, 20,  400 },
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }

        [TestMethod]
        public void decreasingBySum() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.bySum);
            sorter.sort(data,  false);
            int[][] expected = {
               new[] { 3, 99, 99, 99, 99, 99, 100},
               new[] { 2, 20,  400 },
               new[] { 1, 30,  300 },
               new[] { 4, 40,  200},
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }

        [TestMethod]
        public void increasingByMax() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.byMax);
            sorter.sort(data, true);

            int[][] expected = {
               new[] { 3, 99, 99, 99, 99, 99, 100},
               new[] { 4, 40,  200},
               new[] { 1, 30,  300 },
               new[] { 2, 20,  400 },
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }

        [TestMethod]
        public void decreasingByMax() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.byMax);
            sorter.sort(data, false);

            int[][] expected = {
               new[] { 2, 20,  400 },
               new[] { 1, 30,  300 },
               new[] { 4, 40,  200},
               new[] { 3, 99, 99, 99, 99, 99, 100},
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }

        [TestMethod]
        public void increasingByMin() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.byMin);
            sorter.sort(data, true);

            int[][] expected = {
               new[] { 1, 30,  300 },
               new[] { 2, 20,  400 },
               new[] { 3, 99, 99, 99, 99, 99, 100},
               new[] { 4, 40,  200},
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }

        [TestMethod]
        public void decreasingByMin() {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.byMin);
            sorter.sort(data, false);

            int[][] expected = {   
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
            };
            TestUtils.assertJaggedArraysAreEqual(expected, data);
        }
    }
}
