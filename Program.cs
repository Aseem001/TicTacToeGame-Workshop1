using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            char[] gameBoard = ticTacToe.createTicTacToeBoard();           
            char userLetter = ticTacToe.initializeUserLetter();
            char cpuLetter = ticTacToe.initializeCPULetter(userLetter);
            while (true)
            {                
                Console.WriteLine("Enter your nex move: (1-9)");
                int playerPos = Convert.ToInt32(Console.ReadLine());
                while(true)
                {
                    if (gameBoard[playerPos]!=' ')
                    {
                        Console.WriteLine("Invalid selection!");
                        playerPos = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        break;
                }
                ticTacToe.moveToDesiredLocation(gameBoard, playerPos, "PLAYER", userLetter);
                Random random = new Random();
                int cpuPos = random.Next(1, 10);
                while (true)
                {
                    if (gameBoard[cpuPos] != ' ')
                    {
                        cpuPos = random.Next(1, 10);
                    }
                    else
                        break;
                }                
                ticTacToe.moveToDesiredLocation(gameBoard,cpuPos, "CPU",cpuLetter);
                ticTacToe.showBoard(gameBoard);                
            }
        }
    }
}
