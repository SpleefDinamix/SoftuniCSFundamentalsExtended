namespace Animals
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int NumberOfLegs { get; set; }

        public string Talk()
        {
            return "I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.";
        }
    }
}
