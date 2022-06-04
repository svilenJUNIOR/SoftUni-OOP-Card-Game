﻿using BelotCardGame.Contracts;
using BelotCardGame.InputOutput.Contracts;

namespace BelotCardGame.Models
{
    public class Player : IPlayer
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        public Player(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        } 

        private List<Card> Hand { get; set; } = new List<Card>();
        public void FillHand(Card card) => Hand.Add(card);
        public void ShowHand()
        {
            writer.WriteLine("Your hand:");

            foreach (var card in this.Hand)
            {
                if (card.Color == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    writer.WriteLine($"{card.CardType}{card.Suit}");
                }

                else if (card.Color == "black")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    writer.WriteLine($"{card.CardType}{card.Suit}");
                }
            }
            Console.ResetColor();
        }
        public string ChooseGameType(string[] gameTypes)
        {
            writer.WriteLine("\nChoose game type:");

            for (int i = 0; i < gameTypes.Length; i++)
            {
                writer.WriteLine($"{i}: {gameTypes[i]}");
            }

            Console.Write("Enter the number of the desired type: ");
            int gameindex = reader.ReadInt();

            if (gameindex < 0 || gameindex > gameTypes.Length)
                throw new ArgumentException("Invalid number of game type!");

            string game = gameTypes[gameindex];
            return game;
        }
        public List<Card> ReturnHand() => Hand;
    }
}
