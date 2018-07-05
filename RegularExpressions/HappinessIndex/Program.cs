using System;
using System.Text.RegularExpressions;

namespace HappinessIndex
{
    public class Program
    {
        public static void Main()
        {
            var happy = @"(:\))|(:D)|(;\))|(:\*)|(:])|(;])|(:})|(;})|(\(:)|(\*:)|(c:)|(\[:)|(\[;)";
            var happyValidator = new Regex(happy);

            var sad = @"(:\()|(D:)|(;\()|(:\[)|(;\[)|(:{)|(;{)|(\):)|(:c)|(]:)|(];)";
            var sadValidator = new Regex(sad);

            string inputLine = Console.ReadLine();
            int happyEmoticonsCount = happyValidator.Matches(inputLine).Count;
            int sadEmoticonsCount = sadValidator.Matches(inputLine).Count;

            double happinessIndex = Math.Round(happyEmoticonsCount / (double)sadEmoticonsCount, 2);
            string resultEmoticon = String.Empty;

            if (happinessIndex > 2)
                resultEmoticon = ":D";
            else if (happinessIndex > 1)
                resultEmoticon = ":)";
            else if (happinessIndex == 1)
                resultEmoticon = ":|";
            else
                resultEmoticon = ":(";

            Console.WriteLine("Happiness index: {0:F2} {1}", happinessIndex, resultEmoticon);
            Console.WriteLine("[Happy count: {0}, Sad count: {1}]", happyEmoticonsCount , sadEmoticonsCount);
        }
    }
}
