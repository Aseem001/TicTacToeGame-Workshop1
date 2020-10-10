using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create object of the TicTacToe class
            TicTacToe ticTacToe = new TicTacToe();

            //Created new board
            char[] gameBoard = ticTacToe.CreateTicTacToeBoard();
            
            //Call for Toss
            TicTacToe.Player player = ticTacToe.Toss();

            //Game continue after toss
            if (player == TicTacToe.Player.USER)
            {
                ticTacToe.UserMovesFirst(gameBoard);
            }
            else if (player == TicTacToe.Player.CPU)
            {
                ticTacToe.CpuMovesFirst(gameBoard);
            }
        }
    }
}
