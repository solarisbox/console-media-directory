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
    class Song : Media, ISearchable
    {
        private string Title;
        private int Year;
        private string Album;
        private string Artist;

        //Problem : while sending parameters to base class constructor you don't need to use datatype.
        //Solution : Remove string from base() parameter make
        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            this.Title = title;
            this.Year = year;
            this.Album = album;
            this.Artist = artist;
        }

        /// <summary>
        /// Prints formatted information of an object
        /// </summary>
        /// <returns>String of object</returns>
        public override string ToString()
        {
            return string.Format("Song Title: {0} ({1}) \nAlbum: {2} Artist: {3} \n-----------------------", Title, Year, Album, Artist);
        }

        /// <summary>
        /// Compares the title of an object with a search key
        /// </summary>
        /// <param name="key">User input search key</param>
        /// <returns>Boolean</returns>
        public bool Search(string key)
        {
            bool myBool= false;

            myBool = string.Equals(key, this.Title, StringComparison.CurrentCultureIgnoreCase);

            return myBool;
        }
    }
}
