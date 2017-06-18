using System;
using GameReviewsAndSpeedRunning.Data;
using GameReviewsAndSpeedRunning.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConosleApp
{
    class Program
    {
        //private static GameContext _context = new GameContext();
        private static bool keepRunning;

        private static void Main(string[] args)
        {
            MenuLoop();
        }

        private static void MenuLoop()
        {
            keepRunning = true;

            do
            {
                ShowMenu();
                var command = GetCommand();
                ExecuteCommand(command);
            } while (keepRunning);
        }

        private static char GetCommand()
        {
            var command = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return command;
        }

        private static void ExecuteCommand(char command)
        {
            switch (command)
            {
                case 'c':
                    AddGame();
                    break;
                case 'r':
                    FindGame();
                    break;
                case 'u':
                    EditGame();
                    break;
                case 'd':
                    DeleteGame();
                    break;
                case 's':
                    ShowAllGames();
                    break;
                case '1':
                    AddRunner();
                    break;
                case '2':
                    FindRunner();
                    break;
                case '3':
                    EditRunner();
                    break;
                case '4':
                    DeleteRunner();
                    break;
                case '5':
                    ShowAllRunners();
                    break;
                case 'q':
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Error: You have input an Unknown Command! Press any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("--------- Welcome to the Game Review & Speed Running Database ----------");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("---------------------- What would you like to do? ----------------------");
            Console.WriteLine("------ c = 'Add Game'");
            Console.WriteLine("------ r = 'Find Game'");
            Console.WriteLine("------ u = 'Edit Game'");
            Console.WriteLine("------ d = 'Delete Game'");
            Console.WriteLine("------ s = 'Show all Games'");
            Console.WriteLine("");
            Console.WriteLine("------ 1 = 'Add Runner'");
            Console.WriteLine("------ 2 = 'Find Runner'");
            Console.WriteLine("------ 3 = 'Edit Runner'");
            Console.WriteLine("------ 4 = 'Delete Runner'");
            Console.WriteLine("------ 5 = 'Show all Runners'");
            Console.WriteLine("");
            Console.WriteLine("------ q = 'Quit'");
            Console.WriteLine("------------------------------------------------------------------------");
        }


        private static void AddGame()
        {
            Console.WriteLine("--- Please follow the steps for addinga new game! ---");
            Console.WriteLine("Enter the title of the game: ");
            var title = Console.ReadLine();
            Console.WriteLine("Enter the developer of the game: ");
            var developer = Console.ReadLine();
            Console.WriteLine("Enter the Date the game was released: (YYYY/MM/DD)");
            string releaseDate = Console.ReadLine();
            DateTime rd = Convert.ToDateTime(releaseDate);
            Console.WriteLine("Enter the time of the games current world record: (hh:mm:ss)");
            string worldRecord = Console.ReadLine();
            DateTime wr = Convert.ToDateTime(worldRecord);

            var newGame = new Game
            {
                Title = title,
                Developer = developer,
                ReleaseDate = rd,
                WorldRecord = wr,
            };

            using (var context = new GameContext())
            {
                context.Games.Add(newGame);
                context.SaveChanges();
            }
            Console.WriteLine($"The following Game was added: '{title}'");
            Console.WriteLine();
            Console.WriteLine("Thank you for expanding our database! Press any key to go back to the menu.");
            Console.ReadKey();
            Console.Clear();
        }
        private static void FindGame()
        {
            var title = Console.ReadLine();
            var gameFound = new List<string>();
            using (var context = new GameContext())
            {
                gameFound = context.Games.Where(g=>g.Title == title).Select(g=>g.Title).ToList();
            }
            foreach (var game in gameFound)
            {
                Console.WriteLine(game);
            }
            if (gameFound.Count==0)
            {
                Console.WriteLine($"No Game by the name {title} was found");
            }
        }
        private static void EditGame()
        {
            var title = Console.ReadLine();
        }
        private static void DeleteGame()
        {
            var title = Console.ReadLine();
        }
        private static void ShowAllGames()
        {

        }

        private static void AddRunner()
        {
            var name = Console.ReadLine();
            var age = Convert.ToInt32(Console.ReadLine());

            var runner = new Runner
            {
                Name = name,
                Age = age,
            };
        }
        private static void FindRunner()
        {
            var name = Console.ReadLine();
            var runnerFound = new List<string>();
            using (var context = new GameContext())
            {
                runnerFound = context.Runners.Where(r=>r.Name == name).Select(r=>r.Name).ToList();
            }
            foreach (var runner in runnerFound)
            {
                Console.WriteLine(runner);
            }
            if (runnerFound.Count == 0)
            {
                Console.WriteLine($"No Game by the name {name} was found");
            }
        }
        private static void EditRunner()
        {
            var name = Console.ReadLine();
        }
        private static void DeleteRunner()
        {
            var name = Console.ReadLine();
        }
        private static void ShowAllRunners()
        {
            var name = Console.ReadLine();
        }

        private static List<Review> GetReview()
        {
            Console.WriteLine("Please type your review of the game: ");
            var reviewInput = Console.ReadLine();
            Console.WriteLine("Put a grade on the game: (1-10)");
            int gradeInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please leave your name: ");
            var reviewer = Console.ReadLine();

            var review = new Review
            {
                Description = reviewInput,
                Grade = gradeInput,
                ReviewerName = reviewer
            };
            var reviews = new List<Review>
            {
                review
            };
            return reviews;
        }

        private static List<Runner> GetRunner()
        {
            Console.WriteLine("Please insert the name of the runner: ");
            var runnerName = Console.ReadLine();
            Console.WriteLine("Please insert the age of the runner: ");
            int runnerAge = Convert.ToInt32(Console.ReadLine());

            var runner = new Runner
            {
                Name = runnerName,
                Age = runnerAge,
            };
            var runners = new List<Runner>
            {
                runner
            };
            return runners;
        }

        private static void FindGameToReview()
        {
            Console.WriteLine("Type the name of the game you want to review: ");
            var title = Console.ReadLine();
            AddReviewToGame(title);
        }

        private static void AddReviewToGame(string title)
        {
            var context = new GameContext();

            var gameToReview = context.Games.FirstOrDefault(x=>x.Title == title);
            if (gameToReview == null)
            {
                Console.WriteLine("Game does not exist");
                return;
            }
            Console.WriteLine("Type your name: ");
            var reviewerName = Console.ReadLine();
            Console.WriteLine("Type your review: ");
            var description = Console.ReadLine();
            Console.WriteLine("Add a Grade to the game: (1-10)");
            var grade = Convert.ToInt32(Console.ReadLine());

            var review = new Review()
            {
                ReviewerName = reviewerName,
                Game = gameToReview,
                Description = description,
                Grade = grade
            };

            context.Reviews.Add(review);
            context.SaveChanges();
        }

        private static void FindGameToAddRunnerTo()
        {
            var context = new GameContext();

            Console.WriteLine("Type in the title of the Game you want to add a runner to: ");
            var gameName = Console.ReadLine();
            Console.WriteLine("Type the name of the Runner you are going to add to the game: ");
            var runnerName = Console.ReadLine();
            var runner = context.Runners.FirstOrDefault(x=>x.Name == runnerName);
            if (runner == null)
            {
                Console.WriteLine("Runner does not exist! Please add the runner first!");
                return;
            }

            AddRunnerToGame(gameName, runner);


        }
        private static void AddRunnerToGame(string name, Runner runner)
        {
            
            var context = new GameContext();
            var game = context.Games.FirstOrDefault(x => x.Title == name);
            var gameRunner = new GameRunner() {Game = game, Runner = runner };
            runner.GameRunner.Add(gameRunner);

            context.SaveChanges();

        }

        private static void Quit()
        {

        }
    }
}