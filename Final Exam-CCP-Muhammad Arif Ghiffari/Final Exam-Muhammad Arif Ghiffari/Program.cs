using System;

namespace Final_Exam_Muhammad_Arif_Ghiffari
{
    class Program
    {
        //So I make a Tic Tac Toe game for my Assignment Project
        //https://www.youtube.com/watch?v=jiKf-9MLm7Y&t=233s this is my references
        static void Main(string[] args)
        {
            int gameStatus = 0; //the variable in the game whether this game wins or draws
            int playerTurn = -1; // the variable to take turn for both player after selecting the number
            char[] gameNumbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //The Array for input the 'X' or 'O'

            do
            {
                Console.Clear();

                playerTurn = NextPlayer(playerTurn);

                DisplayUp(playerTurn);
                TheBoardGame(gameNumbers);

                GameEngine(gameNumbers, playerTurn);

                gameStatus = checkWinner(gameNumbers);
              

            } while (gameStatus.Equals(0));

            Console.Clear();
            DisplayUp(playerTurn);
            TheBoardGame(gameNumbers);
            
            if (gameStatus.Equals(1))
            {
               
                //one of the player will be win or loose
                Console.WriteLine($"\t\t\t\t\t Player {playerTurn} has won the game!!");
            }

            if (gameStatus.Equals(2))
            {
                //the game is draw
                Console.WriteLine($"\t\t\t\t\t The game is a draw!");
            }
        }
        static void DisplayUp(int PlayerNumber)
        { 
            //Display player, Player 1 is X and Player 2 is O
            Console.WriteLine("Player 1 : X ");
            Console.WriteLine("Player 2 : O ");
            Console.WriteLine();

            //must select the number from 1 to 9
            Console.WriteLine($"\t\t\t Now is Player {PlayerNumber} turn, select the number from 1 to 9 then press Enter.");
            Console.WriteLine();
        }
        static void TheBoardGame(char[] gameNumbers)
        {
            //This is the board game that I custome
            Console.WriteLine("\t\t\t\t\t\t+---+---+---+");
            Console.WriteLine($"\t\t\t\t\t\t| {gameNumbers[0]} | {gameNumbers[1]} | {gameNumbers[2]} |");
            Console.WriteLine("\t\t\t\t\t\t+---+---+---+");
            Console.WriteLine($"\t\t\t\t\t\t| {gameNumbers[3]} | {gameNumbers[4]} | {gameNumbers[5]} |");
            Console.WriteLine("\t\t\t\t\t\t+---+---+---+");
            Console.WriteLine($"\t\t\t\t\t\t| {gameNumbers[6]} | {gameNumbers[7]} | {gameNumbers[8]} |");
            Console.WriteLine("\t\t\t\t\t\t+---+---+---+");
        }

        //to alternate after selecting numbers and output as 'X' or 'O'
        static int NextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;

        }

        private static int checkWinner(char[] gameNumbers)
        {    //when the game is Draw
            if (IsGameDraw(gameNumbers))
            {
                return 2;
            }
            //when one of the player won the game
            if (IsGameWinner(gameNumbers))
            {
                return 1;
            }

        return 0;
        }

        private static bool IsGameDraw(char[] gameNumbers)
        {
            return gameNumbers[0] != '1' &&
                   gameNumbers[1] != '2' &&
                   gameNumbers[2] != '3' &&
                   gameNumbers[3] != '4' &&
                   gameNumbers[4] != '5' &&
                   gameNumbers[5] != '6' &&
                   gameNumbers[6] != '7' &&
                   gameNumbers[7] != '8' &&
                   gameNumbers[8] != '9';
        }

        //it shows the rules of the game if one of the players wins
        private static bool IsGameWinner(char[] gameNumbers)
        {
            if (gameWinner(gameNumbers, 0, 1, 2))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 3, 4, 5))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 6, 7, 8))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 0, 3, 6))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 1, 4, 7))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 2, 5, 8))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 0, 4, 8))
            {
                return true;
            }

            if (gameWinner(gameNumbers, 2, 4, 6))
            {
                return true;
            }
            return false;
        }

        private static bool gameWinner(char[] testGameNumbers, int pos1, int pos2, int pos3)
        {
            return testGameNumbers[pos1].Equals(testGameNumbers[pos2]) && testGameNumbers[pos2].Equals(testGameNumbers[pos3]);
        }

        private static void GameEngine(char[] gameNumbers, int playerTurn)
        {
            bool notValidMove = true;
            do 
            {
                // As the Player places numbers on the game update the board then notify which player has a turn
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                   userInput.Equals("1") ||
                   userInput.Equals("2") ||
                   userInput.Equals("3") ||
                   userInput.Equals("4") ||
                   userInput.Equals("5") ||
                   userInput.Equals("6") ||
                   userInput.Equals("7") ||
                   userInput.Equals("8") ||
                   userInput.Equals("9"))
                {


                    int.TryParse(userInput, out var gamePlacementNumber);

                    char currentNumber = gameNumbers[gamePlacementNumber - 1];

                    if (currentNumber.Equals('X') || currentNumber.Equals('O'))
                    {
                        //don't select a number that has been choose by previous player
                        Console.WriteLine("Placement has already filled please select another number of placement");
                    }
                    else
                    {
                        //if the next turn player not select the same number
                        gameNumbers[gamePlacementNumber - 1] = GetPlayerFilledNumber(playerTurn); //Array always start with number 0 so the varible of "gamePlacementNumber" will be -1
                        notValidMove = false;
                    }
                }
                else
                {    
                    //don't select number above 9 or zero
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        //this how to input the 'X' and 'O' to the board game
        private static char GetPlayerFilledNumber(int playerNumber) 
        {
            if (playerNumber % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }

      

       
    }
}
