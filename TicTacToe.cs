using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
        public enum Player { USER, CPU };
        public char[] createTicTacToeBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public char initializeUserLetter()
        {
            Console.WriteLine("Enter either X or O whichever you want to play with");
            char userValue = Convert.ToChar(Console.ReadLine().ToUpper());
            while (true)
            {
                if (userValue != 'X' && userValue != 'O')
                {
                    Console.WriteLine("Invalid letter input");
                }
                else
                {
                    Console.WriteLine("You have chosen: " + userValue + "\n");
                    return userValue;
                }
            }
        }
        public char initializeCPULetter(char userValue)
        {
            char cpuValue = ' ';
            if (userValue == 'X')
                cpuValue = 'O';
            else
                cpuValue = 'X';
            return cpuValue;
        }
        public void showBoard(char[] board)
        {
            for (int i = 1; i < 8; i += 3)
            {
                Console.WriteLine("\t" + board[i] + " | " + board[i + 1] + " | " + board[i + 2]);
                if (i < 7)
                    Console.WriteLine("\t--+---+--");
            }
        }
        public void moveToDesiredLocation(char[] board, int index, string user, char letter)
        {
            char indexValue = ' ';
            if (user.Equals("USER") || user.Equals("CPU"))
                indexValue = letter;
            board[index] = indexValue;
        }
        public Player toss()
        {
            Random random = new Random();
            Console.WriteLine("Enter\n1-for Heads\n2-for Tails");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            int tossValue = random.Next(1, 3);
            switch (tossValue)
            {
                case 1:
                    Console.WriteLine("Heads it is");
                    break;
                case 2:
                    Console.WriteLine("Tails it is");
                    break;
            }
            if (userChoice == tossValue)
            {
                Console.WriteLine("You can go first");
                return Player.USER;                               
            }
            else
            {
                Console.WriteLine("Cpu will go first");
                return Player.CPU;
            }
        }
        public void userMovesFirst(char[] gameBoard)
        {
            char userLetter = initializeUserLetter();
            char cpuLetter = initializeCPULetter(userLetter);
            while (true)
            {                
                Console.WriteLine("Enter your nex move: (1-9)");
                int playerPos = Convert.ToInt32(Console.ReadLine());
                while (true)
                {
                    if (gameBoard[playerPos] != ' ')
                    {
                        Console.WriteLine("Invalid selection!");
                        playerPos = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        break;
                }
                moveToDesiredLocation(gameBoard, playerPos, "USER", userLetter);
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
                moveToDesiredLocation(gameBoard, cpuPos, "CPU", cpuLetter);
                showBoard(gameBoard);
            }
            
        }
        public void cpuMovesFirst(char[] gameBoard)
        {
            char userLetter = initializeUserLetter();
            char cpuLetter = initializeCPULetter(userLetter);
            while (true)
            {                
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
                moveToDesiredLocation(gameBoard, cpuPos, "CPU", cpuLetter);
                showBoard(gameBoard);
                Console.WriteLine("Enter your nex move: (1-9)");
                int playerPos = Convert.ToInt32(Console.ReadLine());
                while (true)
                {
                    if (gameBoard[playerPos] != ' ')
                    {
                        Console.WriteLine("Invalid selection!");
                        playerPos = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        break;
                }
                moveToDesiredLocation(gameBoard, playerPos, "USER", userLetter);                
            }            
        }
    }
}