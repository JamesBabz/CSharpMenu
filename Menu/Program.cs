using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Menu
{
    class Program
    {
        static int id = 1;
        static List<Video> videos = new List<Video>();

        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "Show Videos",
                "Search for video",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };

            AddDefaultVideos();

            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {
                Clear();
                switch (selection)
                {
                    case 1:
                        ShowVideos();
                        break;
                    case 2:
                        SearchForVideo();
                        break;
                    case 3:
                        AddVideo();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    case 5:
                        EditVideo();
                        break;
                    default:
                        WriteLine("Something went terribly wrong!");
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            WriteLine("Mojn");
            ReadLine();
        }

        private static void SearchForVideo()
        {
            Write("Search: ");
            var query = ReadLine().ToLower();
            bool isFound = false;
            foreach (var video in videos)
            {
                if (video.Name.ToLower().Contains(query)
                    || video.Genre.ToLower().Contains(query)
                    || video.Id.ToString().Contains(query))
                {
                    WriteLine($"Id: {video.Id}. Name: {video.Name}. Genre: {video.Genre}");
                    isFound = true;
                }
            }
            if (!isFound)
                WriteLine("No Matches");
        }

        private static void EditVideo()
        {
            var videoFound = FindVideoById();
            WriteLine($"Current Name: {videoFound.Name}");
            WriteLine("Insert new name:");
            videoFound.Name = ReadLine();
            WriteLine($"Current Genre: {videoFound.Genre}");
            WriteLine("Insert new genre:");
            videoFound.Genre = ReadLine();
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                videos.Remove(videoFound);
            }
            else
            {
                WriteLine("That video was not found");
            }
        }

        private static Video FindVideoById()
        {
            WriteLine("Insert video id:");
            int inputId;
            while (!int.TryParse(ReadLine(), out inputId))
            {
                WriteLine("That is not a valid input");
            }
            Video videoFound = null;

            foreach (var video in videos)
            {
                if (video.Id == inputId)
                {
                    videoFound = video;
                }
            }
            return videoFound;
        }

        private static void AddVideo()
        {
            WriteLine("Input name:");
            var name = ReadLine();
            WriteLine("Input genre:");
            var genre = ReadLine();

            videos.Add(new Video()
            {
                Id = id,
                Name = name,
                Genre = genre
            });
            id++;
        }

        private static void ShowVideos()
        {
            foreach (var video in videos)
            {
                WriteLine($"Id: {video.Id} Name: {video.Name}. Genre: {video.Genre}");
            }
        }

        private static void AddDefaultVideos()
        {
            videos.Add(new Video()
            {
                Id = id,
                Name = "First Video",
                Genre = "Action"
            });
            id++;
            videos.Add(new Video()
            {
                Id = id,
                Name = "Second Video",
                Genre = "Comedy"
            });
            id++;
            videos.Add(new Video()
            {
                Id = id,
                Name = "Third Video",
                Genre = "Thriller"
            });
            id++;
        }

        private static int ShowMenu(string[] menuItems)
        {
            //Clear();
            WriteLine("Select what to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{i + 1}. {menuItems[i]}");
            }
            int selection;
            while (!int.TryParse(ReadLine(), out selection)
                   || selection < 1 || selection > menuItems.Length)
            {
                WriteLine("That is not a valid input");
            }
            return selection;
        }
    }
}