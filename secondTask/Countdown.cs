using System;
using System.Collections.Generic;
using System.Threading;

namespace secondTask {
    public class Countdown {

        private List<MessageListener> observers = new List<MessageListener>();

        public void subscribe(MessageListener obj) {
            Console.WriteLine(obj.GetType().Name + " subscribed\n");
            observers.Add(obj);
        }

        public void unsubscribe(MessageListener obj) {
            Console.WriteLine(obj.GetType().Name + " unsubscribed\n");
            observers.Remove(obj);
        }

        public void notifyAll(int delay, string message) {
            Console.WriteLine($"Notifying subscribers after delay {delay}");
            Thread.Sleep(delay);
            foreach (var listener in observers) {
                listener.onMessageReceived(message);
            }
        }
    }
}
