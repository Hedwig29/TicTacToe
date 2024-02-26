using System.Numerics;

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToe
{
    class Program
    {
        // The board is represented by a char array
        // Доска представлена массивом символов
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static char position;

        // The current player is represented by a char
        // Текущий игрок представлен символом
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            // The game ends when the game is won
            // Игра заканчивается, когда игра выиграна
            bool gameWon = false;

            // Loop until the game is won
            // Цикл до выигрыша игры
            DrawBoard();
            while (!gameWon)
            {
                // Draw the board, get a position, and make a move 
                // Нарисовать доску, получить позицию и сделать ход
                position = GetPosition();
                if (IsValidMove())
                {
                    MakeMove();
                    DrawBoard();
                    //Check if the game is won and switch the player
                    //Проверить, выиграл ли игрок и переключить игрока
                    gameWon = CheckWin();
                    if (!gameWon)
                    {
                        SwitchPlayer();
                        continue;
                    }
                }
                else
                {
                    // The move was invalid, so ask again
                    // Ход был недействителен, поэтому спросите еще раз
                    DrawBoard();
                    Console.WriteLine($"Поле {position} занято, повторите выбор поля.");
                    continue;
                }
                break;
            }

            // Draw the board one last time and print the winner
            // Нарисуйте доску еще раз и напечатайте победителя
            DrawBoard();

            // Print the winner
            // Напечатать победителя
            Console.WriteLine($"Игрок ({currentPlayer}) победил!");
        }

        static void DrawBoard()
        {
            //Clear the console and draw the board
            //Очистить консоль и нарисовать доску
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        static char GetPosition()
        {
            // Ask the current player for a position
            // Спросить текущего игрока о позиции
            do
            {
                Console.WriteLine($"Игрок ({currentPlayer}) выберите номер поля:");
                int.TryParse(Console.ReadLine(), out int position2);
                if (position2 > 0 && position2 < 10)
                {
                    char.TryParse(position2.ToString(), out position);
                    return position;
                }
                else
                {
                    DrawBoard();
                    Console.WriteLine("Введено некорректное значение, повторите выбор.");
                }
            }
            while (true);
        }

        static bool IsValidMove()
        {
            // Check if the position is valid
            // Проверить, действительна ли позиция
            if (Array.Exists(board, x => x == position))
            {
                return true;
            }
            return false;
        }

        static void MakeMove()
        {
            // Make the move
            // Сделать ход
            int.TryParse(position.ToString(), out int numberOfField);
            board[numberOfField - 1] = currentPlayer;
        }

        static bool CheckWin()
        {
            //Check if the current player has won
            //Проверить, выиграл ли текущий игрок
            if (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) { return true; }
            else if (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) { return true; }
            else if (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) { return true; }
            else if (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) { return true; }
            else if (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) { return true; }
            else if (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) { return true; }
            else if (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) { return true; }
            else if (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) { return true; }
            else if (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer) { return true; }



            else //Console.WriteLine("Draw");
            { return false; }
        }

        static void SwitchPlayer()
        {
            // Switch the current player
            // Переключить текущего игрока
            if (currentPlayer == 'X')
                currentPlayer = 'O';
            else
                currentPlayer = 'X';
        }
    }
}