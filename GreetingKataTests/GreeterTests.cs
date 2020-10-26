using System;
using System.Collections;
using System.Collections.Generic;
using GreetingKata;
using Xunit;

namespace GreetingKataTests
{
    public class GreetTests
    {
        [Fact]
        public void ShouldReturnCorrectGreetingMessage_WhenGivenValidName()
        {
            // Arrange
            var greeter = new Greeter();
            var name = "Bob";

            // Act
            var result = greeter.Greet(name);

            // Assert
            Assert.Equal("Hello, Bob.", result);
        }

        [Fact]
        public void ShouldReturnDefaultGreetingMessage_WhenGivenNameIsNull()
        {
            // Arrange
            var greeter = new Greeter();
            string name = null;

            // Act
            var result = greeter.Greet(name);

            // Assert
            Assert.Equal("Hello, my friend.", result);
        }

        [Fact]
        public void ShouldReturnGreetingMessageInUppercase_WhenGivenNameIsInAllCaps()
        {
            // Arrange
            var greeter = new Greeter();
            var name = "JERRY";

            // Act
            var result = greeter.Greet(name);

            // Assert
            Assert.Equal("HELLO, JERRY!", result);
        }

        [Theory]
        [ClassData(typeof(GreetingTestData))]
        public void ShouldReturnCorrectGreetingMessage_WhenGivenAListOfNames(IEnumerable<string> names, string expected)
        {
            // Arrange
            var greeter = new Greeter();

            // Act
            var result = greeter.Greet(names);

            // Assert
            Assert.Equal(expected, result);
        }

        public class GreetingTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {new List<string> {"Jill", "Jane"}, "Hello, Jill and Jane."};
                yield return new object[]
                {
                    new List<string> {"Amy", "Brian", "Charlotte"}, "Hello, Amy, Brian and Charlotte."
                };
                yield return new object[]
                {
                    new List<string> {"Amy", "BRIAN", "Charlotte"}, "Hello, Amy and Charlotte. AND HELLO BRIAN!"
                };
                
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        
    }
}