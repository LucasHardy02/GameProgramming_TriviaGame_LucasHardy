using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameProgramming_TriviaGame_LucasHardy
{
    internal class Program
    {
        static bool gameRunning = true;
        static bool answerPicked = false;
        static bool playAgainPicked = false;
        static int Score;
        static string name;
        static int AnswerNumber = 0;
        static int[] correctAnswerNum = { 1, 3, 2, 2, 4, 1, 1, 2, 2, 3 };
        static List<int> answersSelected = new List<int>();
        static string MainMenu = " /$$$$$$$$        /$$            /$$                  /$$$$$$                                   \r\n|__  $$__/       |__/           |__/                 /$$__  $$                                  \r\n   | $$  /$$$$$$  /$$ /$$    /$$ /$$  /$$$$$$       | $$  \\__/  /$$$$$$  /$$$$$$/$$$$   /$$$$$$ \r\n   | $$ /$$__  $$| $$|  $$  /$$/| $$ |____  $$      | $$ /$$$$ |____  $$| $$_  $$_  $$ /$$__  $$\r\n   | $$| $$  \\__/| $$ \\  $$/$$/ | $$  /$$$$$$$      | $$|_  $$  /$$$$$$$| $$ \\ $$ \\ $$| $$$$$$$$\r\n   | $$| $$      | $$  \\  $$$/  | $$ /$$__  $$      | $$  \\ $$ /$$__  $$| $$ | $$ | $$| $$_____/\r\n   | $$| $$      | $$   \\  $/   | $$|  $$$$$$$      |  $$$$$$/|  $$$$$$$| $$ | $$ | $$|  $$$$$$$\r\n   |__/|__/      |__/    \\_/    |__/ \\_______/       \\______/  \\_______/|__/ |__/ |__/ \\_______/\r\n                                                                                                \r\n                                                                                                \r\n                                                                                                ";
        static string[] Questions = {"How do you draw a map from a text file, that has a height and a width?", "How do you get the console to make a noise?", "What do beginner programmers typically write to console when starting out?", "What number is funnier than 24?", "Where do typically write console code?", "What does having '[]' after a variable type do?", "Whats the recommended amount of dedicated ram you should have for a server?", "what does '!' mean in C#?", "what is a boolean?", "How do you write something to console?"};
        static string[] Answers = { "A for loop", "A while loop", "A foreach loop", "A method", "Console.Noise", "Console.Blip", "Console.Beep", "All of the above", "Hello Console", "Hello World", "Hey there delilah", "None of the above", "67", "25", "Nothing is funnier than 24", "61", "Properties.cs", "App.cs", "References.cs", "None of the above", "Creates an Array", "Creates a List", "Creates an index", "None of the above", "Im sorry, can you please repeat the question", "What do you mean?", "about 5", "None of the above", "I'm excited", "does not", "does", "None of the above", "An operator", "A variable", "A Constant", "None of the above", "Console.Write", "Console.WriteLine", "Both", "Neither"};
        
        static void Main(string[] args)
        {
            while(gameRunning)
            {
                playAgainPicked = false;
                DisplayMainMenuScreen();

                for(int j = 0; j < Questions.Length; j++)
                {
                    Console.WriteLine($"Question {j + 1}/{Questions.Length}:");
                    Console.WriteLine(Questions[j]);
                    Console.WriteLine();

                    for (int i = 0; i < Answers.Length / Questions.Length; i++)
                    {
                        Console.WriteLine($"\n [{i + 1}] " + Answers[AnswerNumber]);
                        AnswerNumber++;
                        Console.WriteLine();
                    }
                    DisplayHUD();
                    
                    answerPicked = false;
                    SelectAnswer(correctAnswerNum[j]);
                    Console.Clear();
                }

                if (answersSelected.Sum() / Questions.Length == 1)
                {
                    EasterEgg();
                }

                DisplayEndingResults();
                PlayAgain();
                Console.Clear();

            }
        }

        static void SelectAnswer(int correctAnswer)
        {
           


            while (answerPicked == false)
            {
                string answer = Console.ReadLine();

                int.TryParse(answer, out int answerInt);

                if (answerInt == correctAnswer)
                {
                    Score = Score + 100;
                    answerPicked = true;
                    answersSelected.Add(answerInt);
                }
                else if (answerInt < 5 && answerInt > 0)
                {
                    answerPicked = true;
                    answersSelected.Add(answerInt);

                }
                else
                {
                    Console.WriteLine("Please select a valid Answer");
                    answerPicked = false;
                    continue;
                }
               

            }

        }
        static void DisplayHUD()
        {
            
            Console.WriteLine("Please Type 1,2,3 or 4, followed by the Enter key to submit your answer");
            Console.WriteLine($"{name}'s Score: {Score/Questions.Length}% / 100%");
        }

        static void DisplayMainMenuScreen()
        {
            
            Console.WriteLine(MainMenu);

            


            Console.ResetColor();

            Console.WriteLine("Please Type Your Name");
            name = Console.ReadLine();
            Console.Clear();

        }

        static void PlayAgain()
        {
            while (playAgainPicked == false)
            {
                string playAgain = Console.ReadLine();

                if (playAgain == "N" || playAgain == "n")
                {
                    gameRunning = false;
                    playAgainPicked = true;
                }
                else if (playAgain == "Y" || playAgain == "y")
                {
                    AnswerNumber = 0;
                    Score = 0;
                    name = null;
                    gameRunning = true;
                    playAgainPicked = true;

                }
                else
                {
                    playAgainPicked = false;
                    Console.WriteLine("Please select a valid answer");
                    continue;
                }
            }
        }
        static void DisplayEndingResults()
        {

            Console.WriteLine($"Your Final Score is: {Score / Questions.Length}% / 100%");
            Console.WriteLine();

            if (Score == 0)
            {
                Console.WriteLine("Were you trying to fail?");
            }
            if (Score > 100 && Score < 500)
            {
                Console.WriteLine("Maybe brush up on your stuff and try again?");
            }
            if (Score == 600)
            {
                Console.Write("You're getting there");
            }
            if (Score == 700)
            {
                Console.WriteLine("Thats pretty good");
            }
            if (Score == 800)
            {
                Console.WriteLine("You did great!");
            }
            if (Score == 900)
            {
                Console.WriteLine("I'm impressed!");
            }
            if (Score == 1000)
            {
                Console.WriteLine("You passed with flying colors! Congrats!");
            }

            Console.WriteLine();
            Console.WriteLine("Play again?");
            Console.WriteLine("Y/N");
        }

        static void EasterEgg()
        {
            Console.WriteLine("Dude, you know there is other keys than just the '1' key right? Ever hear of 2? Did you just blow in from '1' town buddy?");
        }
    }
}
