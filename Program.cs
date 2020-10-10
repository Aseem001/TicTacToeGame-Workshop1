using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            char[] gameBoard = ticTacToe.CreateTicTacToeBoard();                      
            TicTacToe.Player player = ticTacToe.Toss();
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
