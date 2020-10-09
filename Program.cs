using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            char[] gameBoard = ticTacToe.createTicTacToeBoard();                      
            TicTacToe.Player player = ticTacToe.toss();
            if (player == TicTacToe.Player.USER)
            {
                ticTacToe.userMovesFirst(gameBoard);
            }
            else if (player == TicTacToe.Player.CPU)
            {
                ticTacToe.cpuMovesFirst(gameBoard);
            }
        }
    }
}
