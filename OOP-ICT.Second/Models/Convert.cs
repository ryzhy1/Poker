namespace OOP_ICT.Third;

public class Convert
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
       
    };

    public static int ConvertPoints(String denomination, int pointsForAce)
    {
        if (denomination != "Ace")
        {
            return _pointsConverter[denomination];
        }
        
        return pointsForAce;
    }

}