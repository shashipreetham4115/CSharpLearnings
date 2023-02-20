using HandCricketGame.Controller;
using HandCricketGame.Data;
using HandCricketGame.Presentation;

var DatabaseService = new DatabaseService();
var DataController = new DataController(DatabaseService);

var WinnerController = new WinnerController(DataController);
var GestureRoundController = new GestureRoundController(DataController);
var MatchController = new MatchController(DataController, GestureRoundController, WinnerController);
var RecentGameController = new RecentGameController(DataController, MatchController);
var NewGameController = new NewGameController(DataController, MatchController);

var DisplayWinner = new DisplayWinner(MatchController);
var DisplayGame = new DisplayGame(MatchController, DisplayWinner);
var RecentGameChooser = new RecentGameChooser(RecentGameController);

var NewGamePresentationHandler = new NewGamePresentationHandler(NewGameController, DisplayGame);
var ScorecardPresentationHandler = new ScorecardPresentationHandler(RecentGameChooser, DisplayGame);
var MainMenuChooser = new MainMenuChooser();

var PresentationHandler = new PresentationHandler(MainMenuChooser, NewGamePresentationHandler, ScorecardPresentationHandler);

Console.OutputEncoding = System.Text.Encoding.UTF8;
PresentationHandler.Handle();










// Testing

/*using HandCricketGame.Test;

var DatabaseService = new DatabaseService();
DatabaseService.GetPlayers();
DatabaseService.InsertData();*/