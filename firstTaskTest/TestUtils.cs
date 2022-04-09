using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace firstTaskTest {
    public static class TestUtils {

        public static void assertJaggedArraysAreEqual(int[][] expected, int[][] actual) {
            Assert.AreEqual(expected.GetUpperBound(0), actual.GetUpperBound(0));
            for (var i = 0; i < expected.GetUpperBound(0); i++) {
                Assert.AreEqual(expected[i].Length, actual[i].Length);
                for (var j = 0; j < expected[i].Length; j++) {
                    Assert.AreEqual(expected[i][j], actual[i][j]);
                }
            }
        }
    }
}