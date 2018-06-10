namespace Animals
{
    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IntelligenceQuotient { get; set; }

        public string Talk()
        {
            return "I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.";
        }
    }
}
