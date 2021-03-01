using System;
using MyStupidPupidGame.Arena;
using MyStupidPupidGame.Character;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using MyStupidPupidGame.Services.DiceService;

namespace MyStupidPupidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiceService service = new DiceService();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Dice 2 {service.RollDice(EDices.Dice2)}");
                Console.WriteLine($"Dice 4 {service.RollDice(EDices.Dice4)}");
                Console.WriteLine($"Dice 6 {service.RollDice(EDices.Dice6)}");
                Console.WriteLine($"Dice 8 {service.RollDice(EDices.Dice8)}");
                Console.WriteLine($"Dice 10 {service.RollDice(EDices.Dice10)}");
                Console.WriteLine($"Dice 12 {service.RollDice(EDices.Dice12)}");
                Console.WriteLine($"Dice 24 {service.RollDice(EDices.Dice24)}");
                Console.WriteLine($"Dice 100 {service.RollDice(EDices.Dice100)}");
            }
        }
    }
}
