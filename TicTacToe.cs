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
            while (true)
            {
                Console.WriteLine("Enter either X or O whichever you want to play with");
                char userValue = Convert.ToChar(Console.ReadLine().ToUpper());
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
    }
}