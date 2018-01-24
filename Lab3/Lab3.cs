using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 *I, Salvador Valle, #000322660 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * Program Use: The Program takes user input and Creates Shapes based on selection.
 */
namespace Lab3
{
    /// <summary>
    /// This program consumes a text file and stores the data into an array. It prompts a user
    /// to select a number of options in order to display the media information in the console.
    /// </summary>
    class Lab3
    {
        public static int count = 0; //Counter keeps count of instances in myMedia array
        public static string userInput = "-1";

        static void Main(string[] args)
        {
            
            ISearchable[] myMedia = new Media[100];
            ReadData(myMedia);

            while (userInput != "6")
            {
                userInput = Lab3.Menu();
                
                if (userInput != "5") 
                {
                    Lab3.ListMedia(userInput, myMedia);
                }
                else if(userInput == "5")
                {
                    Search(myMedia);
                } 
            }
        }

        /// <summary>
        /// Displays Menu options for Media
        /// </summary>
        /// <returns>Returns a String User Input for Option</returns>
        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title \n");
            Console.WriteLine("6. Exit Program \n");
            Console.WriteLine("Enter choice:");

            string str = Console.ReadLine();
            return str;
        }

        /// <summary>
        /// Prints out all the objects in the Array, depending on User Input
        /// </summary>
        /// <param name="input">User Input String</param>
        /// <param name="mediaArray">An Array of the Media Class, holds Books, Movies and Song Objects</param>
        private static void ListMedia(string input, ISearchable[] mediaArray)
        {
            foreach (ISearchable search in mediaArray)
            {
                switch (input)
                {
                    case "1":
                        Media books = search as Book;
                        if (books != null)
                        {
                            Console.WriteLine(books);
                        }
                        break;
                    case "2":
                        Media movie = search as Movie;
                        if (movie != null)
                        {
                            Console.WriteLine(movie);
                        }
                        break;
                    case "3":
                        Media songs = search as Song;
                        if (songs != null)
                        {
                            Console.WriteLine(songs);
                        }
                        break;
                    case "4":
                        Media media = search as Media;
                        if (media != null)
                        {
                            Console.WriteLine(media);
                        }
                        break;
                    case "6":
                        break;
                    default:
                        //Console.WriteLine("*** Invalid Choice Try Again ***");
                        break;
                }      
            }
            Console.WriteLine("\nPress Any Key to Continue . . .");
            Console.ReadKey();
        }

        /// <summary>
        /// This Method Searches the objects of the array that have the same Title as the searchKey
        /// </summary>
        /// <param name="media">An Array of the Media Class, holds Books, Movies and Song Objects</param>
        private static void Search(ISearchable[] media)
        {
            Console.WriteLine("\nEnter a Search string: ");
            string searchKey = Console.ReadLine();

            foreach (ISearchable search in media)
            {
                if (search != null)
                {
                    if (search.Search(searchKey) == true)
                    {
                        if (Convert.ToString(search.GetType()) == "Lab3.Book")
                        {
                            Book books = search as Book;
                            Console.WriteLine("\n" + books.ToString());
                            Console.WriteLine("\n" + books.Decrypt());
                        }
                        else if (Convert.ToString(search.GetType()) == "Lab3.Movie")
                        {
                            Movie movie = search as Movie;
                            Console.WriteLine("\n" + movie.ToString());
                            Console.WriteLine("\n" + movie.Decrypt());
                        }
                        else
                        {
                            Console.WriteLine("\n" + search.ToString()); 
                        }   
                        Console.WriteLine("\nPress Any Key to Continue . . .");
                        Console.ReadKey();
                    }
                }
            }      
        }

        /// <summary>
        /// Reads a text file and calls the correct Method to create an instance in the myMedia array
        /// </summary>
        /// <param name="media">Array of Media type</param>
        private static void ReadData(ISearchable[] media)
        {
            try
            {
                FileStream file = new FileStream("Data.txt", FileMode.Open, FileAccess.Read);
                StreamReader data = new StreamReader(file);
                string line;

                while ((line = data.ReadLine()) != null)
                {
                    string[] dataArray = line.Split('|');

                    switch (dataArray[0])
                    {
                        case "BOOK":
                            GetBookData(media, dataArray, data);
                            break;
                        case "SONG":
                            GetSongData(media, dataArray);
                            break;
                        case "MOVIE":
                            GetMovieData(media, dataArray, data);
                            break;
                        default:
                            //Console.WriteLine("No Media Found");
                            break;
                    }
                }
                data.Close();
            }
            catch(IOException e)
            {
                Console.WriteLine("Text file not found. \n\nError Message: \n\n" + e.ToString());
            }     
        }

        /// <summary>
        /// Creates an instance of a Song Object in myMedia array
        /// </summary>
        /// <param name="media">array to store instances</param>
        /// <param name="data">array of strings containing data</param>
        private static void GetSongData(ISearchable[] media, string[] data)
        {
            media[count] = new Song(data[1], Convert.ToInt32(data[2]), data[3], data[4]);
            count++;
        }

        /// <summary>
        /// Creates an instance of a Book Object in myMedia array
        /// </summary>
        /// <param name="media">array to store instances</param>
        /// <param name="data">array of strings containing data</param>
        /// <param name="input">StreamReader input for extracting the summary portion of text file</param>
        private static void GetBookData(ISearchable[] media, string[] data, StreamReader input)
        {
            string readLine = "";
            string summary = "";
            
            while ((readLine = input.ReadLine()) != "-----")
            {
                summary = readLine;
            }

            media[count] = new Book(data[1], Convert.ToInt32(data[2]), data[3], summary);
            count++;
        }

        /// <summary>
        /// Creates an instance of a Movie Object in myMedia array
        /// </summary>
        /// <param name="media">array to store instances</param>
        /// <param name="data">array of strings containing data</param>
        /// <param name="input">StreamReader input for extracting the summary portion of text file</param>
        private static void GetMovieData(ISearchable[] media, string[] data, StreamReader input)
        {
            string readLine = "";
            string summary = "";
            
            while ((readLine = input.ReadLine()) != "-----")
            {
                summary = readLine;
            }

            media[count] = new Movie(data[1], Convert.ToInt32(data[2]), data[3], summary);
            count++;
        }
    }
}
