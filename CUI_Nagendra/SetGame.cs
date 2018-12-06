using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUI_Nagendra
{
    class SetGame
    {

        public int rockId;
        public int paperId;
        public int scissorId;

        public SetGame(int rock_Id, int paper_Id, int scissor_Id)
        {
            rockId = rock_Id;
            paperId = paper_Id;
            scissorId = scissor_Id;
        }

        public int GetPlayerCount(string showText)
        {
            int userCount;
            Console.WriteLine(showText);
            userCount = int.Parse(Console.ReadLine());
            while ((userCount < 0))   // iterate till valid input non negative value is given
            {
                Console.WriteLine("Please provide positive integer value, given value is " + userCount);
                Console.WriteLine(showText);
                userCount = int.Parse(Console.ReadLine());  // Get proceed code from user
            }
            return userCount;
        }


        public List<UserDetails> GetUserHandShape(Dictionary<int, string> valueNames, int userPlayerCount, int cpuPlayerCount)
        {
            int i = 1;   // temp variable
            int[] shapeArray = { rockId, paperId, scissorId };
            List<UserDetails> userlist = new List<UserDetails>();
            Random rnd = new Random();              // object to generate random integers
            while (i <= (userPlayerCount + cpuPlayerCount))  // generating list of players details
            {

                if (i <= userPlayerCount)
                {

                    Console.Write("What's Player" + i + "'s hand shape? ==>");
                    valueNames.ToList().ForEach(x => Console.Write(x.Key + ":" + x.Value + " "));
                    Console.WriteLine("");
                    int playerHandShape = int.Parse(Console.ReadLine());

                    while ((!shapeArray.Contains(playerHandShape)))   // iterate till valid input non negative value is given
                    {
                        Console.WriteLine("Please provide correct hand shape value for Player" + i);
                        playerHandShape = int.Parse(Console.ReadLine());   // Get proceed code from user
                    }
                    userlist.Add(new UserDetails { UserName = "Player" + i, HandShape = playerHandShape });
                }
                else
                {
                    userlist.Add(new UserDetails { UserName = "CPU" + (i - userPlayerCount), HandShape = shapeArray[rnd.Next(0, shapeArray.Length)] });
                }

                i++;
            }
            return userlist;
        }


    }


}
