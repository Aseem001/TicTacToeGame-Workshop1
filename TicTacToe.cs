using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
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
        public void moveToDesiredLocation(char[] board,int index,string user,char letter)
        {
            char indexValue = ' ';
            if (user.Equals("PLAYER") || user.Equals("CPU"))
                indexValue = letter;
            board[index] = indexValue;
        }
    }
}