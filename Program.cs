using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            var MVArtist =  from artist in Artists
                            where artist.Hometown == "Mount Vernon"
                            select artist;
            foreach (var artist in MVArtist)
            {
                Console.WriteLine($"The artist from Mount Vernon is {artist.RealName} and is {artist.Age} years old.");
            }
            //Who is the youngest artist in our collection of artists?

            var AllArtists = from artist in Artists
                             select artist;
            var YoungArtist = (from artist in Artists select artist.Age).Min();
            foreach (var artist in AllArtists)
            {
                if (artist.Age == YoungArtist)
                {
                    Console.WriteLine($"The youngest artist is {artist.RealName} and is {artist.Age} years old.");
                }
            }

            //Display all artists with 'William' somewhere in their real name

            Console.WriteLine($"Every artist whos name contains William are:");
            var ArtistWilliam = from artist in Artists
                                where artist.RealName.Contains("William")
                                select artist;
            foreach (var artist in ArtistWilliam)
            {
                Console.WriteLine(artist.RealName);
            }

            //Display the 3 oldest artist from Atlanta

            var OldestArtists = from artist in Artists
                                where artist.Hometown == "Atlanta"
                                orderby artist.Age descending
                                select artist;
            Console.WriteLine("The three oldest artist who live in Atlanta are:");
            foreach (var artist in OldestArtists.Take(3))
            {
                Console.WriteLine($"Name: {artist.RealName} Age: {artist.Age} Hometown: {artist.Hometown}");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	    Console.WriteLine(Groups.Count);
        }
    }
}
