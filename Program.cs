using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {                                               
            while(true)
            {
                //Create object of the TicTacToe class
                TicTacToe ticTacToe = new TicTacToe();

                //Created new board
                char[] gameBoard = ticTacToe.CreateTicTacToeBoard();

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
                bool playAgain = ticTacToe.PlayAgain();
                if (playAgain == false)
                    break;
            }
            
        }
    }
}
