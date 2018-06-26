using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var users = new List<User>();

            while (inputLine != "exit")
            {
                var parts = inputLine
                    .Split();

                if (parts.Contains("register"))
                {
                    string username = parts[1];
                    users.Add(new User()
                    {
                        Username = username,
                        RecievedMessages = new List<Messages>()
                    });
                }
                else
                {
                    string sender = parts[0];
                    string recipient = parts[2];
                    string content = parts[3];

                    var structuredMessage = new Messages()
                    {
                        Content = content,
                        Sender = sender
                    };

                    if (users.Any(x => x.Username == sender))
                    {
                        foreach (var user in users)
                        {
                            if (user.Username == recipient)
                            {
                                user.RecievedMessages.Add(structuredMessage);
                            }
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }
            string[] userPair = Console.ReadLine().Split();

            User firstUser = new User();
            User secondUser = new User();

            foreach (var user in users)
            {
                if (user.Username == userPair[0])
                {
                    List<Messages> filteredMessages = new List<Messages>();
                    foreach (var message in user.RecievedMessages)
                    {
                        if (message.Sender == userPair[1])
                        {
                            filteredMessages.Add(message);
                        }
                    }

                    firstUser = new User()
                    {
                        Username = user.Username,
                        RecievedMessages = filteredMessages
                    };
                }
                else if (user.Username == userPair[1])
                {
                    List<Messages> filteredMessages = new List<Messages>();
                    foreach (var message in user.RecievedMessages)
                    {
                        if (message.Sender == userPair[0])
                        {
                            filteredMessages.Add(message);
                        }
                    }

                    secondUser = new User()
                    {
                        Username = user.Username,
                        RecievedMessages = filteredMessages
                    };
                }
            }

            int userOneIndex = firstUser.RecievedMessages.Count;
            int userTwoIndex = secondUser.RecievedMessages.Count;
            int endIndex = Math.Min(userOneIndex,userTwoIndex);

            for (int i = 0; i < endIndex; i++)
            {
                Console.WriteLine("{0}: {1}", secondUser.RecievedMessages[i].Sender, secondUser.RecievedMessages[i].Content);
                Console.WriteLine("{0} :{1}", firstUser.RecievedMessages[i].Content, firstUser.RecievedMessages[i].Sender);
            }

            for (int i = endIndex; i < firstUser.RecievedMessages.Count; i++)
            {
                Console.WriteLine("{0}: {1}", firstUser.RecievedMessages[i].Sender, firstUser.RecievedMessages[i].Content);
            }

            for (int i = endIndex; i < secondUser.RecievedMessages.Count; i++)
            {
                Console.WriteLine("{0}: {1}", secondUser.RecievedMessages[i].Sender, secondUser.RecievedMessages[i].Content);
            }
        }
    }
}
