using System.Collections.Generic;
using System.Linq;

namespace GreetingKata
{
    public class Greeter
    {
        public string Greet(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "Hello, my friend.";
            
            var isNameInCaps = name == name.ToUpper();
            var hello = isNameInCaps ? "HELLO" : "Hello";
            var endingPunctuation = isNameInCaps ? "!" : ".";
            return $"{hello}, {name}{endingPunctuation}";
        }
        
        public string Greet(IEnumerable<string> names)
        {
            // var greetingNames = string.Join(" and ", names);
            var namesList = names.ToList();
            var normalCaseNameList = namesList.Where(name => name != name.ToUpper()).ToList();
            var upperCaseNameList = namesList.Where(name => name == name.ToUpper()).ToList();
            
            var normalCaseNameCount = normalCaseNameList.Count();
            var normalCaseNameList1 = normalCaseNameList.GetRange(0, normalCaseNameCount - 1);
            var normalCaseNamesCommaDelimited = DelimitWithComma(normalCaseNameList1);
            
            var upperCaseGreetingMessage = "";
            if (upperCaseNameList.Count > 0)
                upperCaseGreetingMessage = $" AND HELLO {upperCaseNameList[0]}!";
            
            return $"Hello, {normalCaseNamesCommaDelimited} and {normalCaseNameList[normalCaseNameCount - 1]}.{upperCaseGreetingMessage}";
        }

        private string DelimitWithComma(List<string> names)
        {
            return string.Join(", ", names);
        }
    }
}