using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONStringify
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var students = new List<Student>();

            while (inputLine != "stringify")
            {
                var studentParams = inputLine
                    .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                var nameAndAge = studentParams[0]
                    .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var grades = new List<int>();
                if (studentParams.Length > 1)
                {
                    grades = studentParams[1]
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                }
                    

                students.Add(new Student()
                {
                    Name = nameAndAge[0],
                    Age = int.Parse(nameAndAge[1]),
                    Grades = grades
                });

                inputLine = Console.ReadLine();
            }

            var jBuilder = new StringBuilder();
            jBuilder.Append("[");

            foreach (var student in students)
            {
                jBuilder.Append("{");

                var jStudent = String.Format("name:\"{0}\",age:{1},grades:[{2}]",
                    student.Name, student.Age, String.Join(", ", student.Grades));
                jBuilder.Append(jStudent);

                jBuilder.Append("},");
            }
            jBuilder.Remove(jBuilder.Length - 1, 1);
            jBuilder.Append("]");

            Console.WriteLine(jBuilder.ToString());
        }
    }
}
