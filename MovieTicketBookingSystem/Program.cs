using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation;
using MovieTicketBookingSystem.Controller;
using System.Runtime.Serialization.Json;
using MovieTicketBookingSystem.Practice;
using MovieTicketBookingSystem.Util;

var Data = GenerateDummyData();
/*string unicode = "\U+25A1";*/
Console.OutputEncoding = System.Text.Encoding.UTF8;
Driver();
//PrintData();
/*new Practice();*/


void Driver()
{
    var DataHandler = new DataHandler(Data);

    var TheatreHandler = new TheatreDataHandler(DataHandler);
    var MovieController = new MovieDataController(DataHandler);
    var SeatController = new SeatDataController();


    var TheatreChooser = new TheatreChooser(TheatreHandler);
    var DateChooser = new DateChooser();
    var MovieChooser = new MovieChooser(MovieController);
    var ShowChooser = new ShowChooser();
    var SeatChooser = new SeatChooser(SeatController);
    var RebookingChooser = new RebookingChooser();

    var uiHandler = new PresentationHandler(TheatreChooser, DateChooser, MovieChooser, ShowChooser, SeatChooser, RebookingChooser);
    uiHandler.Handle();
}

List<Theatre> GenerateDummyData()
{
    var uniqueIdGenerator = UniqueIdGenerator.GetInstance();

    var Seats = new List<Seat>();
    for (char i = 'A'; i <= 'F'; i++)
    {
        for (int j = 1; j <= 10; j++)
        {
            Seats.Add(new Seat(i, j));
        }
    }

    var Shows = new List<List<Show>>();
    for (int a = 0; a < 5; a++)
    {
        var Show1 = new Show(uniqueIdGenerator.GetUniqueId(), 1, DateTime.Today.AddDays(a).AddHours(7), DeepClone(Seats), Seats.Count);
        var Show2 = new Show(uniqueIdGenerator.GetUniqueId(), 1, DateTime.Today.AddDays(a).AddHours(10), DeepClone(Seats), Seats.Count);
        var Show3 = new Show(uniqueIdGenerator.GetUniqueId(), 1, DateTime.Today.AddDays(a).AddHours(13), DeepClone(Seats), Seats.Count);
        var Show4 = new Show(uniqueIdGenerator.GetUniqueId(), 1, DateTime.Today.AddDays(a).AddHours(16), DeepClone(Seats), Seats.Count);
        var Show5 = new Show(uniqueIdGenerator.GetUniqueId(), 1, DateTime.Today.AddDays(a).AddHours(19), DeepClone(Seats), Seats.Count);
        Shows.Add(new List<Show> { Show1, Show2, Show3, Show4, Show5 });
    }

    var MoviesList = new List<List<Movie>>();
    for (int a = 0; a < 5; a++)
    {
        var Movie1 = new Movie(uniqueIdGenerator.GetUniqueId(), "Michael", DeepClone(Shows[a]));
        var Movie2 = new Movie(uniqueIdGenerator.GetUniqueId(), "Varisu", DeepClone(Shows[a]));
        var Movie3 = new Movie(uniqueIdGenerator.GetUniqueId(), "Thunivu", DeepClone(Shows[a]));
        var Movie4 = new Movie(uniqueIdGenerator.GetUniqueId(), "Pathaan", DeepClone(Shows[a]));
        var Movie5 = new Movie(uniqueIdGenerator.GetUniqueId(), "Love Today", DeepClone(Shows[a]));
        MoviesList.Add(new List<Movie> { Movie1, Movie2, Movie3, Movie4, Movie5 });
    }

    var Movies = new Dictionary<DateTime, List<Movie>> {
        { DateTime.Today.Date, MoviesList[0] },
        { DateTime.Today.AddDays(1).Date, MoviesList[1] },
        { DateTime.Today.AddDays(2).Date, MoviesList[2] },
        { DateTime.Today.AddDays(3).Date, MoviesList[3] },
        { DateTime.Today.AddDays(4).Date, MoviesList[4] }
     };

    var Theatre1 = new Theatre(uniqueIdGenerator.GetUniqueId(), "Sathyam Cinemas", "Chennai", Movies);
    var Theatre2 = new Theatre(uniqueIdGenerator.GetUniqueId(), "Udhayam Cinemas", "Chennai", DeepClone(Movies));
    var Theatre3 = new Theatre(uniqueIdGenerator.GetUniqueId(), "Kasi theatre", "Chennai", DeepClone(Movies));
    var Theatre4 = new Theatre(uniqueIdGenerator.GetUniqueId(), "Vetri theatres, Chromepet", "Chennai", DeepClone(Movies));
    var Theatre5 = new Theatre(uniqueIdGenerator.GetUniqueId(), "Inox", "Chennai", DeepClone(Movies));

    return new List<Theatre> { Theatre1, Theatre2, Theatre3, Theatre4, Theatre5 };
}

T DeepClone<T>(T original)
{
    T clone;
    using (var memoryStream = new MemoryStream())
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        serializer.WriteObject(memoryStream, original);
        memoryStream.Position = 0;
        clone = (T)serializer.ReadObject(memoryStream);
    }
    return clone;
}

void PrintData()
{
    //Data?.ForEach(t => Console.WriteLine(t.ToString()));
    List<Movie>? movies = null;
    Data?[0].Movies.TryGetValue(DateTime.Today.AddDays(2), out movies);
    movies?[0].Shows.ForEach(show => Console.WriteLine(show.ToString()));
}