using OOP_ICT.First.Models;

namespace OOP_ICT.Fourth.Combinations;

public abstract class Chain
{
    private Chain _combinationChecker;
    
    public PokerCombination DetermineResult(Chain combinationChecker,List<Card> cards)
    {
        _combinationChecker = combinationChecker;
        return _combinationChecker.GetChainResult(cards);
    }

    public abstract PokerCombination GetChainResult(List<Card> cards);



}