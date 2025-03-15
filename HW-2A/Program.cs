using System;
using System.Collections.Generic;

class Deck
{
    private List<string> cards = new List<string>();
    private int currentIndex = 0;

    public Deck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        
        // Populate the deck with all 52 cards
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                cards.Add($"{rank} of {suit}");
            }
        }
    }

    // Method to deal a card from the deck
    public string DealCard()
    {
        if (currentIndex < cards.Count)
        {
            return cards[currentIndex++];
        }
        throw new InvalidOperationException("No more cards in the deck");
    }
}

class Program
{
    static void Main()
    {
        // Create a deck of cards (DON'T SHUFFLE THE DECK)
        Deck deck = new Deck();
        
        // Create a list to store players' hands
        List<List<string>> players = new List<List<string>>();
        for (int i = 0; i < 4; i++) players.Add(new List<string>());

        // Deal 2 cards to each player in proper order
        for (int round = 0; round < 2; round++)
        {
            for (int i = 0; i < 4; i++)
            {
                players[i].Add(deck.DealCard());
            }
        }

        // Deal 1 more card to players 2 and 3
        players[1].Add(deck.DealCard());
        players[2].Add(deck.DealCard());

        // Print the cards for each player
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Player {i + 1}:");
            foreach (var card in players[i])
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
        }
    }
}
