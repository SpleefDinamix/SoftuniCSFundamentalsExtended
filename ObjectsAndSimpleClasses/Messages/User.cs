using System.Collections.Generic;

namespace Messages
{
    public class User
    {
        public string Username { get; set; }
        public List<Messages> RecievedMessages { get; set; }

    }
}
