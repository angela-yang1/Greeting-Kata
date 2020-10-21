using System.Collections.Generic;

namespace GreetingKata
{
    public class Greeter
    {
        public string Greet(string name)
        {
            var isNameEmpty = string.IsNullOrEmpty(name);
            var isNameInCaps = name == name?.ToUpper();

            var standardGreetingMessage = $"Hello, {(isNameEmpty ? "my friend" : name)}.";
            var upperCaseGreetingMessage = $"HELLO, {name}!";
            
            return isNameInCaps ?  upperCaseGreetingMessage : standardGreetingMessage;
        }

        public string Greet(IEnumerable<string> names)
        {
            var greetingNames = string.Join(" and ", names);

            return $"Hello, {greetingNames}.";
        }
    }
}