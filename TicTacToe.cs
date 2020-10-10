using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
        public enum Player { USER, CPU };
        static int counter = 0;
        public char[] CreateTicTacToeBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public char InitializeUserLetter()
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
        public char InitializeCPULetter(char userValue)
        {
            char cpuValue = ' ';
            if (userValue == 'X')
                cpuValue = 'O';
            else
                cpuValue = 'X';
            return cpuValue;
        }
        public void ShowBoard(char[] board)
        {
            for (int i = 1; i < 8; i += 3)
            {
                Console.WriteLine("\t" + board[i] + " | " + board[i + 1] + " | " + board[i + 2]);
                if (i < 7)
                    Console.WriteLine("\t--+---+--");
            }
        }
        public void MoveToDesiredLocation(char[] board, int index, string user, char letter)
        {
            char indexValue = ' ';
            if (user.Equals("USER") || user.Equals("CPU"))
                indexValue = letter;
            board[index] = indexValue;
            counter++;
        }
        public Player Toss()
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
        public void UserMovesFirst(char[] gameBoard)
        {
            char userLetter = InitializeUserLetter();
            char cpuLetter = InitializeCPULetter(userLetter);
            PlayLogic(gameBoard, userLetter, cpuLetter);                                  
        }
        public void CpuMovesFirst(char[] gameBoard)
        {
            char userLetter = InitializeUserLetter();
            char cpuLetter = InitializeCPULetter(userLetter);
            Random rand = new Random();
            int cpuFirstPos = rand.Next(1, 10);
            MoveToDesiredLocation(gameBoard, cpuFirstPos, "CPU", cpuLetter);
            ShowBoard(gameBoard);
            PlayLogic(gameBoard, userLetter, cpuLetter);                     
        }
        public bool HasWon(char[] board)
        {            
            for (int i = 1; i < 8; i += 3)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i]!=' ')
                {
                    return true;
                }
            }
            if (board[1] == board[4] && board[4] == board[7] && board[1] != ' ')
                return true;
            if ((board[2] == board[5]) && (board[5] == board[8]) && board[2] != ' ')
                return true;
            if (board[3].Equals(board[6]) && board[6].Equals(board[9]) && board[3] != ' ')
                return true;
            if ((board[3] == board[5]) && (board[5] == board[7]) && board[3] != ' ')
                return true;
            if ((board[1] == board[5]) && (board[5] == board[9]) && board[1] != ' ')
                return true;
            else
                return false;
        }
        public int GetComputerMove(char[] board, char userLetter, char cpuLetter)
        {
            int winningMove = GetWinningMove(board, cpuLetter);
            int userWinningMove = GetWinningMove(board, userLetter);
            if (winningMove != 0)
                return winningMove;
            if (userWinningMove != 0)
                return userWinningMove;
            return 0;
        }
        public int GetWinningMove(char[] board,char letter)
        {
            for(int index=1; index< board.Length; index++)
            {
                char[] copyBoard = GetCopyOfBoard(board);
                if (copyBoard[index] == ' ')
                {
                    copyBoard[index] = letter;
                    if (HasWon(copyBoard))
                        return index;
                }                    
            }
            return 0;
        }
        public char[] GetCopyOfBoard(char[] board)
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, 0, boardCopy, 0, board.Length);
            return boardCopy;
        }
        public void PlayLogic(char[] gameBoard, char userLetter, char cpuLetter)
        {
            while (true)
            {
                while (HasWon(gameBoard) == false && counter < 9)
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
                    MoveToDesiredLocation(gameBoard, playerPos, "USER", userLetter);
                    if (HasWon(gameBoard) == true)
                    {
                        Console.WriteLine("Congrats! You won");
                        break;
                    }
                    else if (counter == 9)
                        break;
                    int cpuPos = GetComputerMove(gameBoard,userLetter, cpuLetter);
                    if (cpuPos != 0)
                        MoveToDesiredLocation(gameBoard, cpuPos, "CPU", cpuLetter);
                    else
                    {
                        Random random = new Random();
                        int cpuPosAlternate = random.Next(1, 10);
                        while (true)
                        {
                            if (gameBoard[cpuPosAlternate] != ' ')
                            {
                                cpuPosAlternate = random.Next(1, 10);
                            }
                            else
                                break;
                        }
                        MoveToDesiredLocation(gameBoard, cpuPosAlternate, "CPU", cpuLetter);
                    }
                    ShowBoard(gameBoard);
                    if (HasWon(gameBoard) == true)
                    {
                        Console.WriteLine("\nSorry! CPU won :(");
                        break;
                    }
                }
                if (HasWon(gameBoard) == true)
                    break;
                else if (counter == 9)
                {
                    Console.WriteLine("Sorry, but this was a tie game!");
                    break;
                }
            }
        }
    }
}