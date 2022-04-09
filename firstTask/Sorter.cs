namespace firstTask {
    public class Sorter {

        public Comparator comparator { private get; set; }

        public Sorter(Comparator comparator) {
            this.comparator = comparator;
        }

        public void sort(int[][] data, bool isIncreasingOrder) {
            quickSort(data, isIncreasingOrder, 0, data.GetLength(0) - 1);
        }

        private void quickSort(int[][] arr, bool isIncreasingOrder, int left, int right) {
            if (left >= right) {
                return;
            }
            var pivot = calculatePivot(arr, isIncreasingOrder, left, right);

            if (pivot > 1) {
                quickSort(arr, isIncreasingOrder, left, pivot - 1);
            }
            if (pivot + 1 < right) {
                quickSort(arr, isIncreasingOrder, pivot + 1, right);
            }

        }

        private int calculatePivot(int[][] arr, bool isIncreasingOrder, int left, int right) {
            var pivot = arr[left];
            while (true) {
                var comparison = comparator(arr[left], pivot);
                while (isIncreasingOrder && comparison < 0 || !isIncreasingOrder && comparison > 0) {
                    left++;
                    comparison = comparator(arr[left], pivot);
                }

                comparison = comparator(arr[right], pivot);
                while (isIncreasingOrder && comparison > 0 || !isIncreasingOrder && comparison < 0) {
                    right--;
                    comparison = comparator(arr[right], pivot);
                }

                if (left < right) {
                    if (arr[left] == arr[right]) return right;

                    (arr[right], arr[left]) = (arr[left], arr[right]);
                } else {
                    return right;
                }
            }
        }
    }
}
