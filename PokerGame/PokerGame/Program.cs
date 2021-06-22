using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame
{
    class Program
    {
        enum typeOfPlayer { PlayerA, PlayerB };


        private static bool Pick(List<int> pokers, Random random, typeOfPlayer player)
        {
            int rowIndex = random.Next(0, pokers.Count);
            int totalCount = pokers[rowIndex];
            int count = random.Next(1, totalCount + 1);
            Console.WriteLine("{0}, Row: {1}-{2}, ,Count: {3}-{4}", player, pokers.Count, rowIndex, totalCount, count);
            pokers[rowIndex] -= count;
            if (pokers[rowIndex] == 0)
                pokers.RemoveAt(rowIndex);

            if (pokers.Count == 0)
            {
                Console.WriteLine("{0}, You lost", player.ToString());
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            List<int> pokers = new List<int>();
            Random rdm = new Random();
            for (int i = 0; i < 3; i++)
            {
                pokers.Add((i + 1) * 2 + 1);
            }

            List<typeOfPlayer> players = new List<typeOfPlayer>() { typeOfPlayer.PlayerA, typeOfPlayer.PlayerB };
            while (pokers.Count > 0)
            {
                foreach (var player in players)
                {
                    if (Pick(pokers, rdm, player))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Game Over");
        }
    }
}
