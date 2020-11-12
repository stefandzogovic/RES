using Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.IO;
using Common;

namespace Tests
{
    [TestFixture]
    public class ConsoleTest
    {
        public class ConsoleWrapperStub : IConsole
        {
            private IList<ConsoleKey> keyCollection;
            private int keyIndex = 0;

            public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
            {
                this.keyCollection = keyCollection;
            }

            public string Output = string.Empty;

            public ConsoleKeyInfo ReadKey()
            {
                var result = keyCollection[this.keyIndex];
                keyIndex++;
                return new ConsoleKeyInfo((char)result, result, false, false, false);
            }

            public void WriteLine(string data)
            {

            }

            public string ReadLine()
            {
                return "xd";
            }

            public void Interface(IConsole console)
            {

            }

            public void Write(string data)
            {
                Output += data;
            }
        }

        public static string GetMaskedInput(string prompt, IConsole console)
        {
            string pwd = "";
            ConsoleKeyInfo key;
            do
            {
                key = console.ReadKey();
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pwd += key.KeyChar;
                    console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pwd.Length > 0)
                    {
                        pwd = pwd.Substring(0, pwd.Length - 1);
                        console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return pwd;
        }

        [Test]
        public void If_Enter_first_then_return_empty_pwd()
        {
            // Arrange
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.Enter });
            var expectedResult = String.Empty;
            var expectedConsoleOutput = String.Empty;

            // Act

            var actualResult = GetMaskedInput(string.Empty, stub);

            //     
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(stub.Output, Is.EqualTo(expectedConsoleOutput));
        }

        [Test]
        public void If_two_chars_return_pass_and_output_coded_pass()
        {
            // Arrange
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.Enter });
            var expectedResult = "AB";
            var expectedConsoleOutput = "**";

            // Act

            var actualResult = GetMaskedInput(string.Empty, stub);

            //     
            
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(stub.Output, Is.EqualTo(expectedConsoleOutput));
        }

        [Test]

        public void TestGettingInput()
        {
            var console = new TestableConsole("abc");

            var classObject = new TestClass(console);

            Assert.Throws<ArgumentException>(() => classObject.RunBusinessRules());
        }
       
    }

    public class TestClass
    {
        private readonly IConsole _console;

        public TestClass(IConsole console)
        {
            _console = console;
        }

        public void RunBusinessRules()
        {
            int value;
            if (!int.TryParse(_console.ReadLine(), out value))
            {
                throw new ArgumentException("User input was not valid");
            }
        }
    }

    public class TestableConsole : IConsole
    {
        private readonly string _output;

        public TestableConsole(string output)
        {
            _output = output;
        }

        public string ReadLine()
        {
            return _output;
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);

        }

        public void WriteLine(string msg)
        {

        }

        public void Write(string msg)
        {

        }

        public void Interface(IConsole console)
        {

        }
    }
}
