using OOP_ICT.First.Models;
using OOP_ICT.Fourth;
using OOP_ICT.Second.Models.Factories;

List<PokerPlayer> pokerPlayers = new List<PokerPlayer>();
        
var pokerCasino = new PokerCasino(new CasinoAccountFactory());
var pokerPlayer1 = new PokerPlayer(1, 50);
var pokerPlayer2 = new PokerPlayer(2, 50);
var dealer = new Dealer();
var table = new Table();

pokerPlayer1.CreateAccount(pokerCasino, 50, pokerPlayer1);
pokerPlayer2.CreateAccount(pokerCasino, 50, pokerPlayer2);
        
pokerPlayers.Add(pokerPlayer1);
pokerPlayers.Add(pokerPlayer2);

var pokerGame = new PokerGameFacade(pokerCasino, pokerPlayers, 0);
pokerGame.StartGame(pokerCasino, dealer, 10, 20, table);

pokerGame.GetWinner(table);
