using System.Collections.Generic;

namespace JSONStringify
{
    public partial class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<int> Grades { get; set; }
        }
    }
}
