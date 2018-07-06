using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    public class Program
    {
        public static void Main()
        {
            var participants = Console.ReadLine()
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToArray();

            var availableSongs = Console.ReadLine()
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToArray();

            var inputLine = Console.ReadLine();
            var participantsDict = new Dictionary<string, SortedSet<string>>();

            while (inputLine != "dawn")
            {
                var parts = inputLine
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToArray();

                string participant = parts[0];
                string song = parts[1];
                string award = parts[2];

                if (participants.Contains(participant) && availableSongs.Contains(song))
                {
                    if (!participantsDict.Keys.Contains(participant))
                    {
                        participantsDict.Add(participant, new SortedSet<string>());
                    }
                    participantsDict[participant].Add(award);
                }

                inputLine = Console.ReadLine();
            }

            if (participantsDict.Keys.Count < 1)
            {
                Console.WriteLine("No awards");
                return;
            }

            participantsDict = participantsDict
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var participantAward in participantsDict)
            {
                string participant = participantAward.Key;
                var awards = participantAward.Value;

                string nameAndAwardCount = $"{participant}: {awards.Count} awards";
                Console.WriteLine(nameAndAwardCount);

                foreach (var award in awards.OrderBy(x => x))
                {
                    Console.WriteLine("--" + award);
                }
            }
        }
    }
}
