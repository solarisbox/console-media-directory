using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *I, Salvador Valle, #000322660 certify that this material is my original work. 
 * No other person's work has been used without due acknowledgement.
 * Program Use: The Program takes user input and Creates Shapes based on selection.
 */
namespace Lab3
{
    class Movie : Media, ISearchable, IEncryptable
    {
        private string Director;
        private string Summary;
        private string Title;
        private int Year;

        public Movie(string title, int year, string director, string summary)
            : base(title, year)
        {
            this.Title = title;
            this.Year = year;
            this.Director = director;
            this.Summary = summary;
        }

        /// <summary>
        /// Prints formatted information of an object
        /// </summary>
        /// <returns>String of object</returns>
        public override string ToString()
        {
            return string.Format("Movie Title: {0} ({1}) \nDirector: {2} \n-----------------------", Title, Year, Director);
        }

        /// <summary>
        /// Compares the title of an object with a search key
        /// </summary>
        /// <param name="key">User input search key</param>
        /// <returns>Boolean</returns>
        public bool Search(string key)
        {
            bool myBool = false;

            myBool = string.Equals(key, this.Title, StringComparison.CurrentCultureIgnoreCase);

            return myBool;
        }

        /// <summary>
        /// Summary information of Movie
        /// </summary>
        /// <returns>Summary String</returns>
        public string Encrypt()
        {
            return this.Summary;
        }

        /// <summary>
        /// Decrypts the summary of the Movie using ROT13
        /// https://www.dotnetperls.com/rot13
        /// </summary>
        /// <returns>string array</returns>
        public string Decrypt()
        {
            char[] array = this.Summary.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }
    }
}
