using OOP_ICT.Fourth.Combinations;

public class Converter
{
    private static Dictionary<String, int> _pointsConverter = new Dictionary<string, int>()
    {
        { "Two", 2 },
        { "Three", 3 },
        { "Four", 4 },
        { "Five", 5 },
        { "Six", 6 },
        { "Seven", 7 },
        { "Eight", 8 },
        { "Nine", 9 },
        { "Ten", 10 },
        { "Jack", 10 },
        { "Queen", 10 },
        { "King", 10 },
        { "Ace", 10 }
    };

    public static int Convert(String rank)
    {
        return _pointsConverter[rank];
    }
}