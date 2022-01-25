using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Name
{
    class Program
    {
        static void Main()
        {
            string[] textNumbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "minus", "plus" };
            string input = Console.ReadLine();

            int n = 0;
            foreach (var number in textNumbers)
            {
                if (n == 10) input = input.Replace(number, "-");
                else if (n == 11) input = input.Replace(number, "+");
                else input = input.Replace(number, n.ToString());
                n++;
            }
            string inputTmp = input;

            int answerInNumber = Calculate(input);

            char[] numbers = answerInNumber.ToString().ToCharArray();
            string answerInString = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].ToString() == "-") answerInString += "minus";
                else answerInString += textNumbers[int.Parse(numbers[i].ToString())];
            }

            string output = $"input -> {inputTmp}\nAnswer in number -> {answerInNumber}\nAnswer in string -> {answerInString}";
            Console.WriteLine(output);

        }

        static int Calculate(string input)
        {
            string tmpForNumber = "";
            string firstEqualatinElement = input.Substring(0, 1);
            if (firstEqualatinElement == "-" || firstEqualatinElement == "+")
            {
                tmpForNumber += firstEqualatinElement;
                input = input.Substring(1);
                firstEqualatinElement = input.Substring(0, 1);
            }

            int answerInNumber = 0;
            while (input.Length > 0)
            {
                tmpForNumber += firstEqualatinElement;
                input = input.Substring(1);
                if (input.Length > 0) firstEqualatinElement = input.Substring(0, 1);
                else answerInNumber += int.Parse(tmpForNumber);
                if (firstEqualatinElement == "-" || firstEqualatinElement == "+")
                {
                    answerInNumber += int.Parse(tmpForNumber);
                    tmpForNumber = "";
                    tmpForNumber += firstEqualatinElement;
                    input = input.Substring(1);
                    firstEqualatinElement = input.Substring(0, 1);
                }
            }
            return answerInNumber;
        }
    }
}
