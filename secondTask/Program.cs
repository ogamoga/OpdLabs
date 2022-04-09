using System;

namespace secondTask {
    internal class FirstObserver : MessageListener{
        public void onMessageReceived(string message) {
            Console.WriteLine(message + " was received in firstObserver\n");
        }
    }

    internal class SecondObserver : MessageListener {
        public void onMessageReceived(string message) {
            Console.WriteLine(message + " was received in secondObserver\n");
        }
    }

    internal static class Program {
        private static void Main(string[] args) {
            var countdown = new Countdown();
            var firstObserver = new FirstObserver();
            var secondObserver = new SecondObserver();

            countdown.subscribe(firstObserver);

            Console.Write("Enter delay in milisseconds: ");
            int delay;
            while (!int.TryParse(Console.ReadLine(), out delay)) { }
            countdown.notifyAll(delay, $"User event with delay {delay}");

            countdown.notifyAll(1000, "May I have your attention, please?");

            countdown.subscribe(secondObserver);
            countdown.notifyAll(2000, "Will the real Slim Shady please stand up?");

            countdown.unsubscribe(secondObserver);
            countdown.notifyAll(3000, "I repeat, will the real Slim Shady please stand up ?");

            countdown.unsubscribe(firstObserver);
            countdown.notifyAll(4000, "We're gonna have a problem here?");

            Console.ReadKey();
        }
    }
}
