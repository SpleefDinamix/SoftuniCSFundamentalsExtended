using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONParse
{
    public class Program
    {
        public static void Main()
        {
            var students = new List<Student>();

            string jString = Console.ReadLine();
            var jStudents = jString
                .Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x != "[" && x != "]" && x != ",")
                .ToList();

            foreach (var jStudent in jStudents)
            {

                var parts = jStudent
                    .Split(new[] { ' ', ',', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                string studentName = parts[0]
                    .Split(new[] { ':', '\"' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last();

                int studentAge = int.Parse(parts[1]
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last());

                int[] grades = parts
                    .Skip(3)
                    .Select(int.Parse)
                    .ToArray();

                students.Add(new Student()
                {
                    Name = studentName,
                    Age = studentAge,
                    Grades = grades
                });
            }

            students
                .ForEach(x =>
                {
                    string grades = x.Grades.Length > 0 ? String.Join(", ", x.Grades) : "None";
                    Console.WriteLine("{0} : {1} -> {2}",
                        x.Name, x.Age, grades);
                });
        }
    }
}
