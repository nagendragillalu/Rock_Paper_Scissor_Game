using System;
using System.Collections.Generic;
using System.Linq;

namespace CUI_Nagendra
{
    class Program
    {
        static void Main(string[] args)
        {

            int gameFlag = 1;                       // flag to decide to proceed for next(1) round or not(0)
                                                    // int userValue, compValue = 1;           // declare user and cpu value holder

            int userPlayerCount, cpuPlayerCount;    // number of user players and CPU players 
            int sCount = 0, rCount = 0, pCount = 0;

            // create dictory for values lookup for given inputs
            Dictionary<int, string> valueNames = new Dictionary<int, string>();

            int rockId = 10;
            int paperId = 20;
            int scissorId = 30;

            valueNames.Add(rockId, "Rock");
            valueNames.Add(paperId, "Paper");
            valueNames.Add(scissorId, "Scissor");

            Console.WriteLine("Start of Rock–paper–scissors game.");

            while (gameFlag != 0)
            {

                try
                {
                    sCount = 0; rCount = 0; pCount = 0; // intialize the count

                    SetGame game = new SetGame(rockId, paperId, scissorId);
                    userPlayerCount = game.GetPlayerCount("Please enter number of user Players");// Get number of User Players
                    cpuPlayerCount = game.GetPlayerCount("Please enter number of CPU Players"); // Get number of CPU Players

                    List<UserDetails> userlist;   // Crete list of UserDetails type

                    userlist = game.GetUserHandShape(valueNames, userPlayerCount, cpuPlayerCount);


                    foreach (UserDetails ulist in userlist)               // Iterating on list display given handshapes and to find the players point
                    {

                        Console.WriteLine(ulist.UserName + "'s handshape is " + valueNames[ulist.HandShape]);
                        if (ulist.HandShape == rockId)
                        {
                            pCount++;   // points for paper when rock is handshape
                        }
                        else if (ulist.HandShape == paperId)
                        {
                            sCount++;   //  points for scissors when paper is handshape
                        }
                        else if (ulist.HandShape == scissorId)
                        {
                            rCount++;  // points for rock when scissor is handshape
                        }

                    }

                    WinnerSellection winSelector = new WinnerSellection(rCount, sCount, pCount, valueNames);
                    if ((userPlayerCount + cpuPlayerCount) <= 2)
                    {
                        winSelector.SignglePlayerWinner(userlist, rockId, paperId, scissorId);
                    }
                    else
                    {
                        winSelector.GetWinnerMulti(userlist, rockId, paperId, scissorId);
                    }


                    Console.WriteLine("Do you want to continue? (1: Continue game, 0: Exit game)");
                    gameFlag = int.Parse(Console.ReadLine());  // Get proceed code from user
                    while ((gameFlag > 1) || (gameFlag < 0))   // iterate till valid input is given 1 or 0
                    {

                        Console.WriteLine("Please provide correct value, given value is " + gameFlag);
                        Console.WriteLine("Do you want to continue? (1: Continue game, 0: Exit game)");
                        gameFlag = int.Parse(Console.ReadLine());  // Get proceed code from user

                    }

                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message + " Please provide integer number only");
                    Console.WriteLine("Do you want to continue? (1: Continue game, 0: Exit game)");
                    gameFlag = int.Parse(Console.ReadLine());  // Get proceed code from user
                    while ((gameFlag > 1) || (gameFlag < 0))   // iterate till valid input is given 1 or 0
                    {

                        Console.WriteLine("Please provide correct value, given value is " + gameFlag);
                        Console.WriteLine("Do you want to continue? (1: Continue game, 0: Exit game)");
                        gameFlag = int.Parse(Console.ReadLine());  // Get proceed code from user

                    }
                }


            }

        }
    }
}
