using System.Linq;

namespace firstTask {

    public delegate int Comparator(int[] o1, int[] o2);
    public static class Comparators {

        public static int bySum(int[] o1, int[] o2) => o1.Sum() - o2.Sum();
        public static int byMax(int[] o1, int[] o2) => o1.Max() - o2.Max();
        public static int byMin(int[] o1, int[] o2) => o1.Min() - o2.Min();
    }
}
