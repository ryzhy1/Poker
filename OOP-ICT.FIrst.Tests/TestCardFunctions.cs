using OOP_ICT.First.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    /// <summary>
    /// Тесты пишутся из трех частей итог - данные - что вернуло 
    /// </summary>
    [Fact]
    public void AreEquals_InputIsValueAndSuit_ReturnTrue()
    {
        // Пока карты не написаны ,давайте проверим числа и строки
        var value = 10;
        var suit = "some suit";

        Assert.Equal(10, value);
        Assert.Equal("some suit", suit);
    }

    [Fact]
    public void AreEquals_InputIsDeckSize_ReturnTrue()
    {
        var cardDeck = new CardDeck().Deck;
        var actualCardDeckSize = cardDeck.Count();

        Assert.Equal(52, actualCardDeckSize);
    }

    [Fact]
    public void AreNotEqual_InputIsCardDeck_ReturnTrue()
    {
        var cardDeck = new CardDeck().Deck;
        var shaffledDeck = new PerfectShuffleAlgorithm().ShuffleAlgorithm(cardDeck);
        Assert.NotEqual(cardDeck, shaffledDeck);
    }

    [Fact]
    public void AreEqual_InputIsCardDeckAndHashMap_ReturnTrue()
    {
        var cardDeck = new CardDeck().Deck;

        HashSet<Card> uniqueCards = new HashSet<Card>(cardDeck);
        Assert.Equal(cardDeck.Count, uniqueCards.Count);
    }
}