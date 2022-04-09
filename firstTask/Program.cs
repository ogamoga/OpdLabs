using System;

namespace firstTask {

    class Program {
        private static void showArray(int[][] data) {
            Console.WriteLine();
            foreach (var arr in data) {
                foreach (var item in arr) {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args) {
            int[][] data = {
                new[] { 2, 20,  400 },
                new[] { 1, 30,  300 },
                new[] { 4, 40,  200},
                new[] { 3, 99, 99, 99, 99, 99, 100},
            };

            var sorter = new Sorter(Comparators.bySum);
            sorter.sort(data, true);
            Console.WriteLine("Increasing sort by sum");
            showArray(data);
            sorter.sort(data, false);
            Console.WriteLine("Decreasing sort by sum");
            showArray(data);
            
            sorter.comparator = Comparators.byMax;
            sorter.sort(data, true);
            Console.WriteLine("Increasing sort by max");
            showArray(data);
            sorter.sort(data, false);
            Console.WriteLine("Decreasing sort by max");
            showArray(data);
                       
            sorter.comparator = Comparators.byMin;
            sorter.sort(data, true);
            Console.WriteLine("Increasing sort by min");
            showArray(data);
            sorter.sort(data, false);
            Console.WriteLine("Decreasing sort by min");
            showArray(data);
            Console.ReadLine();
        }
    }
}
