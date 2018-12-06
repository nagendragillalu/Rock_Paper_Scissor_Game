using System;
using System.Collections.Generic;
using System.Text;

namespace CUI_Nagendra
{
    class WinnerSellection
    {
        private readonly int rCount;
        private readonly int sCount;
        private readonly int pCount;
        private readonly Dictionary<int, string> valueNames;


        public WinnerSellection(int rockPoints, int scissorsPoint, int paperPoint, Dictionary<int, string> valuenames)
        {
            rCount = rockPoints;
            pCount = paperPoint;
            sCount = scissorsPoint;
            valueNames = valuenames;
        }

        public WinnerSellection(Dictionary<int, string> valuenames)
        {

            valueNames = valuenames;
        }


        public void GetWinnerMulti(List<UserDetails> userlist, int rockId, int paperId, int scissorId)
        {
            if (((rCount > sCount) && (rCount > pCount) && (sCount != 0) && (pCount != 0)) || ((sCount == 0) && (rCount != 0) && (pCount != 0)))   // if rock has max points when Scissors is not 0 or scissor is 0
            {
                foreach (UserDetails ulist in userlist)
                {
                    if (ulist.HandShape == rockId)
                    {
                        Console.WriteLine("-->" + ulist.UserName + " has won with Handshape " + valueNames[ulist.HandShape]);
                    }
                }
            }

            else if (((sCount > pCount) && (sCount > rCount) && (pCount != 0) && (rCount != 0)) || ((pCount == 0) && (sCount != 0) && (rCount != 0)))           // if scissors has max points and paper is not 0
            {
                foreach (UserDetails ulist in userlist)
                {
                    if (ulist.HandShape == scissorId)
                    {
                        Console.WriteLine("-->" + ulist.UserName + " has won with Handshape " + valueNames[ulist.HandShape]);
                    }
                }
            }

            else if (((pCount > rCount) && (pCount > sCount) && (rCount != 0) && (sCount != 0)) || ((rCount == 0) && (pCount != 0) && (sCount != 0)))         // if paper has max points and rock is not 0     
            {
                foreach (UserDetails ulist in userlist)
                {
                    if (ulist.HandShape == paperId)
                    {
                        Console.WriteLine("-->" + ulist.UserName + " has won with Handshape " + valueNames[ulist.HandShape]);
                    }
                }
            }
            else if ((pCount == rCount) || (pCount == sCount))
            {
                Console.WriteLine("It's a Draw Please play again");
            }
            else if ((rCount == sCount) || (rCount == pCount))
            {
                Console.WriteLine("It's a Draw Please play again");
            }
            else
            {
                Console.WriteLine("Its's a Draw Please Play again");
            }
        }



        public void SignglePlayerWinner(List<UserDetails> userlist, int rockId, int paperId, int scissorId) // this method is to decide the winner when 2 players only,either 2 users only or 2 CPU's only
        {

            if (userlist.Count > 1)
            {
                if (userlist[0].HandShape != userlist[1].HandShape)
                {
                    if (((userlist[0].HandShape == rockId) && (userlist[1].HandShape == paperId)) || ((userlist[0].HandShape == scissorId) && (userlist[1].HandShape == rockId)) || ((userlist[0].HandShape == paperId) && (userlist[1].HandShape == scissorId)))
                    {
                        Console.WriteLine(userlist[0].UserName + "'s hand shape : " + valueNames[userlist[0].HandShape] + " & " + userlist[1].UserName + "'s hand shape :" + valueNames[userlist[1].HandShape]);
                        Console.WriteLine(userlist[1].UserName + " Won");

                    }
                    else if (((userlist[0].HandShape == paperId) && (userlist[1].HandShape == rockId)) || ((userlist[0].HandShape == rockId) && (userlist[1].HandShape == scissorId)) || ((userlist[0].HandShape == scissorId) && (userlist[1].HandShape == paperId)))
                    {
                        Console.WriteLine(userlist[0].UserName + "'s hand shape : " + valueNames[userlist[0].HandShape] + " & " + userlist[1].UserName + "'s hand shape :" + valueNames[userlist[1].HandShape]);
                        Console.WriteLine(userlist[0].UserName + " Won");

                    }

                }
                else
                {
                    Console.WriteLine(userlist[0].UserName + "'s hand shape : " + valueNames[userlist[0].HandShape] + " & " + userlist[1].UserName + "'s hand shape :" + valueNames[userlist[1].HandShape]);
                    Console.WriteLine("It's a Draw Please play again");
                }

            }
            else
            {
                Console.WriteLine("Please play with atleast 2 players");
            }
        }

    }

}

