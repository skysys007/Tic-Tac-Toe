using System;

class Program
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static int position = 0;
    static char player = 'X';

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            ShowBoard();

            Console.WriteLine("WASD = Move | Enter = Place " + player);

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.W)
                position -= 3;

            if (key == ConsoleKey.S)
                position += 3;

            if (key == ConsoleKey.A)
                position--;

            if (key == ConsoleKey.D)
                position++;

            // Keep cursor inside board
            if (position < 0) position = 0;
            if (position > 8) position = 8;

            if (key == ConsoleKey.Enter)
            {
                if (board[position] == ' ')
                {
                    board[position] = player;

                    if (Winner())
                    {
                        Console.Clear();
                        ShowBoard();
                        Console.WriteLine(player + " Wins!");
                        break;
                    }

                    player = player == 'X' ? 'O' : 'X';
                }
            }
        }
    }

    static void ShowBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i == position)
                Console.Write("[" + board[i] + "]");
            else
                Console.Write(" " + board[i] + " ");

            if (i % 3 == 2)
                Console.WriteLine();
            else
                Console.Write("|");
        }
    }

    static bool Winner()
    {
        int[,] win =
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (int i = 0; i < 8; i++)
        {
            if (board[win[i, 0]] == player &&
                board[win[i, 1]] == player &&
                board[win[i, 2]] == player)
                return true;
        }

        return false;
    }
}
