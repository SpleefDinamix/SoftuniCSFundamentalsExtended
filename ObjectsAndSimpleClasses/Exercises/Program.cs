using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public class Program
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            var exercises = new List<Exercise>();

            while (inputLine != "go go go")
            {
                string[] parts = inputLine
                    .Split(new[] { ' ', ',', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                exercises.Add(new Exercise()
                {
                    Topic = parts[0],
                    CourseName = parts[1],
                    JudgeContestLink = parts[2],
                    Problems = parts.Skip(3).ToArray()
                });

                inputLine = Console.ReadLine();
            }

            foreach (var exercise in exercises)
            {
                Console.WriteLine("Exercises: {0}",exercise.Topic);
                Console.WriteLine("Problems for exercises and homework for the \"{0}\" course @ SoftUni.", exercise.CourseName);
                Console.WriteLine("Check your solutions here: {0}",exercise.JudgeContestLink);

                for (int i = 0; i < exercise.Problems.Length; i++)
                {
                    Console.WriteLine("{0}. {1}", i+1, exercise.Problems[i]);
                }
            }
        }
    }
}
