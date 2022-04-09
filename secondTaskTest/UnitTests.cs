using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using secondTask;

namespace secondTaskTest {
    
    internal class TestObserver : MessageListener {
        public void onMessageReceived(string message) {
            Console.WriteLine(message + " was received in testObserver\n");
        }
    }
    
    internal class AnotherTestObserver : MessageListener {
        public void onMessageReceived(string message) {
            Console.WriteLine(message + " was received in anotherTestObserver\n");
        }
    }
    
    [TestClass]
    public class UnitTest1 {
        
        [TestMethod]
        public void isObserverCreatesCorrectly() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            observer.onMessageReceived("test_message");
            
            Assert.IsTrue(stringWriter.ToString().Contains("test_message was received in testObserver"));
        }

        [TestMethod]
        public void isSubscribeRegistersCorrectly() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            var countdown = new Countdown();
            countdown.subscribe(observer);
            
            Assert.AreEqual("TestObserver subscribed\n\r\n", stringWriter.ToString());
        }
        
        [TestMethod]
        public void isUnsubscribeRegistersCorrectly() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            var countdown = new Countdown();
            countdown.unsubscribe(observer);
            
            Assert.AreEqual("TestObserver unsubscribed\n\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void isMessagesReceivesAfterSubscribe() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            var countdown = new Countdown();
            countdown.subscribe(observer);
            countdown.notifyAll(0, "test_message");

            var outputLines = stringWriter.ToString().Split('\n');
            Assert.AreEqual("test_message was received in testObserver", outputLines[3]);
        }
        
        [TestMethod]
        public void isMessagesStopsAfterUnsubscribe() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            var countdown = new Countdown();
            countdown.subscribe(observer);
            countdown.unsubscribe(observer);
            countdown.notifyAll(0, "test_message");

            var outputLines = stringWriter.ToString().Split('\n');
            Assert.IsFalse(outputLines.Any(s => s.Contains("received")));
        }
        
        [TestMethod]
        public void isMessagesReceivesByMultipleSubscribers() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            var observer = new TestObserver();
            var anotherObserver = new AnotherTestObserver();
            var countdown = new Countdown();
            countdown.subscribe(observer);
            countdown.subscribe(anotherObserver);
            countdown.notifyAll(0, "test_message");

            var outputLines = stringWriter.ToString().Split('\n');
            Assert.IsTrue(outputLines.Count(s => s.Contains("received")) == 2);
        }
    }
}
