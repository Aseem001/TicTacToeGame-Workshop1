using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            char[] board = ticTacToe.createTicTacToeBoard();            
        }
    }
}
