using System;
using System.Collections.Generic;

public class StartUp
{
    private static Card biggest;
    private static string winner;

    public static void Main()
    {
        Game();
    }

    public static void WinnerCheck(Card card, string player)
    {
        if (card.CompareTo(biggest) > 0)
        {
            biggest = card;
            winner = player;
        }
    }

    public static void Game()
    {
        var firstPlayer = Console.ReadLine();
        var secondPlayer = Console.ReadLine();

        List<Card> deck = GenerateDeck();
        List<Card> firstDeck = new List<Card>();
        List<Card> secondDeck = new List<Card>();

        while (firstDeck.Count < 5 || secondDeck.Count < 5)
        {
            var inputArgs = Console.ReadLine().Split(' ');
            try
            {
                var card = new Card(inputArgs[0], inputArgs[2]);
                if (deck.Contains(card))
                {
                    deck.Remove(card);
                    if (firstDeck.Count < 5)
                    {
                        firstDeck.Add(card);
                        WinnerCheck(card, firstPlayer);
                    }
                    else
                    {
                        secondDeck.Add(card);
                        WinnerCheck(card, secondPlayer);
                    }
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No such card exists.");
            }
        }
        Console.WriteLine($"{winner} wins with {biggest.Name}.");
    }

    public static void PrintDeck()
    {
        var deck = GenerateDeck();
        foreach (var card in deck)
        {
            Console.WriteLine(card.Name);
        }
    }

    public static List<Card> GenerateDeck()
    {
        List<Card> deck = new List<Card>();
        foreach (var suit in Enum.GetNames(typeof(Suit)))
        {
            foreach (var rank in Enum.GetNames(typeof(Rank)))
            {
                deck.Add(new Card(rank, suit));
            }
        }
        return deck;
    }

    public static void PrintAttribute()
    {
        var input = Console.ReadLine();

        if (input == "Rank")
        {
            PrintAttribute(typeof(Rank));
        }
        else
        {
            PrintAttribute(typeof(Suit));
        }
    }

    public static void PrintAttribute(Type type)
    {
        var attributes = type.GetCustomAttributes(false);
        Console.WriteLine(attributes[0]);
    }

    public static void Task1()
    {
        var input = Console.ReadLine();
        Console.WriteLine($"{input}:");
        foreach (var suit in Enum.GetValues(typeof(Rank)))
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }

    public static void PrintEnums(Type type)
    {
        var input = Console.ReadLine();
        Console.WriteLine($"{input}:");
        foreach (var value in Enum.GetValues(type))
        {
            Console.WriteLine($"Original value: {(int)value}; Name value: {value}");
        }
    }

    public static void PrintCardInfo()
    {
        Card card = ReadCard();

        Console.WriteLine(card);
    }

    public static Card ReadCard()
    {
        var rank = Console.ReadLine();
        var suit = Console.ReadLine();

        Card card = new Card(rank, suit);
        return card;
    }

    public static void CompareCards()
    {
        Card first = ReadCard();
        Card second = ReadCard();

        if (first.CompareTo(second) > 0)
        {
            Console.WriteLine(first);
        }
        else
        {
            Console.WriteLine(second);
        }
    }
}
