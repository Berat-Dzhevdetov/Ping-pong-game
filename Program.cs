using System;
using System.Collections.Generic;
using System.Threading;

namespace pingpong
{
    class Program
    {
        static int ballPositionX = Console.WindowWidth / 2;
        static int ballPositionY = Console.WindowHeight / 2;
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int dificulty = 0;
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static int firstPlayerPadSize = 5;
        static int secondPlayerPadSize = 5;
        static int firstPlayerScore = 0;
        static int secondPlayerScore = 0;
        static Random randomGenerator = new Random();
        static bool someOneWin = false;

        static void Main(string[] args)
        {
            RemoveScrollBars();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 16, Console.WindowHeight / 2);
            Console.WriteLine("One or two player?");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1);
            string twoPlayerOrAI = Console.ReadLine().ToLower();
            bool isAIorPlayers = TwoPlayerOrAI(twoPlayerOrAI);
            if (isAIorPlayers)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 26, Console.WindowHeight / 2);
                Console.WriteLine("Please enter difficulty: (easy,normal,hard,impossible)");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 1);
                string diffucultyInString = Console.ReadLine().ToLower();
                ChoosingDifficulty(diffucultyInString);
            }
            Console.Clear();
            SetInitialPositions();
            while (!isAIorPlayers)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo firstInfo = Console.ReadKey();
                    if (firstInfo.Key == ConsoleKey.W)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (firstInfo.Key == ConsoleKey.S)
                    {
                        MoveFirstPlayerDown();
                    }
                    if (firstInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveSecondPlayerUp();
                    }
                    if (firstInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveSecondPlayerDown();
                    }
                }
                Console.Clear();
                MoveBall();
                DrawFirstPlayer();
                DrawSecondPlayer();
                someOneWin = SomeOneReachThePoints();
                if (someOneWin)
                {
                    WhoWins();
                        break;
                }
                DrawBall();
                DrawResult();
                Thread.Sleep(60);
            }
            while (isAIorPlayers)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo firstInfo = Console.ReadKey();
                    if (firstInfo.Key == ConsoleKey.W)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (firstInfo.Key == ConsoleKey.S)
                    {
                        MoveFirstPlayerDown();
                    }
                }
                Console.Clear();
                DrawFirstPlayer();
                MoveAI();
                MoveBall();
                DrawSecondPlayer();
                DrawBall();
                DrawResult();
                someOneWin = SomeOneReachThePoints();
                if (someOneWin)
                {
                    WhoWins();
                    break;
                }
                Thread.Sleep(60);
            }

        }
        static bool SomeOneReachThePoints()
        {
            if (firstPlayerScore >= 9 || secondPlayerScore >= 9)
            {
                return true;
            }
            return false;
        }
        static void WhoWins()
        {
            if (firstPlayerScore >= 9)
            {
                Console.Clear();
                Console.WriteLine($"Player 1 Wins!");
            }
            else if (secondPlayerScore >= 9)
            {
                Console.Clear();
                Console.WriteLine($"Player 2 Wins!");
            }
        }
        static void MoveBall()
        {
            if (ballPositionX <2)
            {
                if (ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }
            if (ballPositionX > Console.WindowWidth -2 -1)
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY < firstPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }
            if (ballPositionX == Console.WindowWidth -1)
            {
                firstPlayerScore++;
                SetInitialPositions();
                ballDirectionRight = false;
                ballDirectionUp = true;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2);
                Console.WriteLine("Player 1 beat");
                Console.ReadKey();
            }
            if (ballPositionX == 0)
            {
                secondPlayerScore++;
                SetInitialPositions();
                ballDirectionRight = true;
                ballDirectionUp = true;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2);
                Console.WriteLine("Player 2 beat");
                Console.ReadKey();
            }
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }
            if (ballPositionY == Console.WindowHeight-1)
            {
                ballDirectionUp = true;
            }
            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;                     
            }
            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }
        static void MoveAI()
        {
            int randomNumber = randomGenerator.Next(1, 101);
            if (dificulty == 50)
            {
                if (randomNumber <= 50)
                {
                    if (ballDirectionUp)
                    {
                        MoveSecondPlayerUp();
                    }
                    else
                    {
                        MoveSecondPlayerDown();
                    }
                }
            }
            else if (dificulty == 65 )
            {
                if (randomNumber <= 65)
                {
                    if (ballDirectionUp)
                    {
                        MoveSecondPlayerUp();
                    }
                    else
                    {
                        MoveSecondPlayerDown();
                    }
                }
            }
            else if (dificulty == 80)
            {
                if (randomNumber <= 80)
                {
                    if (ballDirectionUp)
                    {
                        MoveSecondPlayerUp();
                    }
                    else
                    {
                        MoveSecondPlayerDown();
                    }
                }
            }
            else if (dificulty == 90)
            {
                if (randomNumber <= 90)
                {
                    if (ballDirectionUp)
                    {
                        MoveSecondPlayerUp();
                    }
                    else
                    {
                        MoveSecondPlayerDown();
                    }
                }
            }
        }
        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }
        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition++;
            }
        }
        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }
        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }
        }
        static void DrawResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.WriteLine($"{firstPlayerScore}-{secondPlayerScore}");
        }
        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }
        static void SetInitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }
        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '|');
            }
        }
        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.BufferWidth - 1, y, '|');
            }
        }
        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbol);
        }
        static bool TwoPlayerOrAI(string twoPlayerOrAI)
        {
            if (twoPlayerOrAI.Contains("two"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void ChoosingDifficulty(string diffucultyInString)
        {
            if (diffucultyInString == "easy")
            {
                dificulty = 50;
            }
            else if (diffucultyInString == "normal")
            {
                dificulty = 65;
            }
            else if (diffucultyInString == "hard")
            {
                dificulty = 80;
            }
            else if (diffucultyInString == "impossible")
            {
                dificulty = 90;
                firstPlayerPadSize = 4;
            }
            else
            {
                dificulty = 65;
            }
            return;
        }
    }
}
