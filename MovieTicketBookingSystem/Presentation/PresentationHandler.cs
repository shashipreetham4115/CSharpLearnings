using MovieTicketBookingSystem.Model;
using MovieTicketBookingSystem.Presentation.Contract;

namespace MovieTicketBookingSystem.Presentation
{
	public class PresentationHandler
	{
        protected ITheatreChooser TheatreChooser;
        protected IMovieChooser MovieChooser;
        protected IDateChooser DateChooser;
        protected IShowChooser ShowChooser;
        protected ISeatChooser SeatChooser;
        protected IRebookingChooser RebookingChooser;

        public PresentationHandler(
            ITheatreChooser theatreChooser, IDateChooser dateChooser,
            IMovieChooser movieChooser, IShowChooser showChooser,
            ISeatChooser seatChooser, IRebookingChooser rebookingChooser
        )
        {
            TheatreChooser = theatreChooser;
            DateChooser = dateChooser;
            MovieChooser = movieChooser;
            ShowChooser = showChooser;
            SeatChooser = seatChooser;
            RebookingChooser = rebookingChooser;
        }

        public void Handle()
		{
            int sCase = 1;
            string city = "Chennai";
            Theatre? theatre = null;
            DateTime? date = null;
            Movie? movie = null;
            Show? show = null;
            Ticket? ticket = null;
            while (true)
            {
                switch (sCase)
                {
                    case 1:
                        // Read Theatre Input
                        theatre = TheatreChooser.Choose(city);
                        if (theatre == null) sCase--; else sCase++;
                        break;

                    case 2:
                        // Get Date Input
                        date = DateChooser.Choose(DateTime.Today.Date, DateTime.Today.AddDays(4).Date);
                        if (date == null) sCase--; else sCase++;
                        break;

                    case 3:
                        // Get Movie Input
                        movie = MovieChooser.Choose(theatre!, date??DateTime.Today.Date);
                        if (movie == null) sCase--; else sCase++;
                        break;

                    case 4:
                        // Get Show Input
                        show = ShowChooser.Choose(movie!, date ?? DateTime.Today.Date);
                        if (show == null) sCase--; else sCase++;
                        break;

                    case 5:
                        // Get Input of Seats
                        ticket = SeatChooser.Choose(show!, theatre!.Id, movie!.Id);
                        if (ticket == null) sCase--; else sCase++;
                        break;
                    case 6:
                        // Get Input For Rebooking or Exit
                        bool rebooking = RebookingChooser.Choose(ticket!, theatre!, movie!);
                        if (rebooking) sCase = 1; else sCase++;
                        break;

                    default:
                        Console.WriteLine("\nThank you, visit again\n");
                        Console.ReadLine();
                        return;
                }
            }
        }
	}
}

