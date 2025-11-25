using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming_TriviaGame_LucasHardy
{
    internal class Program
    {
        static bool gameRunning = true;
        static bool answerPicked;
        static int Score;
        static string name;
        static string MainMenu = " /$$$$$$$$        /$$            /$$                  /$$$$$$                                   \r\n|__  $$__/       |__/           |__/                 /$$__  $$                                  \r\n   | $$  /$$$$$$  /$$ /$$    /$$ /$$  /$$$$$$       | $$  \\__/  /$$$$$$  /$$$$$$/$$$$   /$$$$$$ \r\n   | $$ /$$__  $$| $$|  $$  /$$/| $$ |____  $$      | $$ /$$$$ |____  $$| $$_  $$_  $$ /$$__  $$\r\n   | $$| $$  \\__/| $$ \\  $$/$$/ | $$  /$$$$$$$      | $$|_  $$  /$$$$$$$| $$ \\ $$ \\ $$| $$$$$$$$\r\n   | $$| $$      | $$  \\  $$$/  | $$ /$$__  $$      | $$  \\ $$ /$$__  $$| $$ | $$ | $$| $$_____/\r\n   | $$| $$      | $$   \\  $/   | $$|  $$$$$$$      |  $$$$$$/|  $$$$$$$| $$ | $$ | $$|  $$$$$$$\r\n   |__/|__/      |__/    \\_/    |__/ \\_______/       \\______/  \\_______/|__/ |__/ |__/ \\_______/\r\n                                                                                                \r\n                                                                                                \r\n                                                                                                ";
        static string[] Questions = {"How do you draw a map from a text file, that has a height and a width?", "What is " };
        static string[][] AllQuestionsAnswers = {Question1Answers, Question2Answers};
        static string[] Question1Answers = {"[1] A for loop", "[2] A while loop", "[3] A foreach loop", "[4] A method" };
        static string[] Question2Answers = { "" };
        static void Main(string[] args)
        {
            while(gameRunning)
            {
                DisplayMainMenuScreen();

                for(int j = 0; j < Questions.Length; j++)
                {
                    Console.WriteLine($"Question {j + 1}/{Questions.Length}:");
                    Console.WriteLine(Questions[j]);
                    Console.WriteLine();

                    for (int i = 0; i < AllQuestionsAnswers.Length; i++)
                    {
                        Console.WriteLine(AllQuestionsAnswers[i]);
                       
                        
                        Console.WriteLine();
                        
                    }

                    DisplayHUD();
                    string answer = Console.ReadLine();
                    answerPicked = false;
                    SelectAnswer(answer, "1");
                    Console.Clear();

                }

            }
        }

        static void SelectAnswer(string answer, string correctAnswer)
        {

            bool Correct;
            int.TryParse(answer, out int answerInt);
            int.TryParse(correctAnswer, out int correctAnswerInt);
            while(answerPicked == false)
            {
                if (answerInt == correctAnswerInt)
                {
                    Correct = true;
                    Score = Score + 1;
                    answerPicked = true;
                }
                else if (answerInt < 5 && !(answer == correctAnswer))
                {
                    Correct = false;
                    answerPicked = true;

                }
                else
                {
                    Console.WriteLine("Please select a valid Answer");
                    answer = Console.ReadLine();
                    answerPicked = false;
                    continue;
                   
                }
            }
            
        }
        static void DisplayHUD()
        {   
            Console.WriteLine("Please Type 1,2,3 or 4, followed by the Enter key to submit your answer");
            Console.WriteLine($"{name}'s Score: {Score}");
        }

        static void DisplayMainMenuScreen()
        {
            Console.WriteLine(MainMenu);
            Console.WriteLine("Please Type Your Name");
            name = Console.ReadLine();
            Console.Clear();

        }
    }
}
