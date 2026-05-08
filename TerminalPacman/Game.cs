// mutable

using System;

using System.Threading;

public class Game

{

    private GameState state;

    public Game(GameState initial)

    {

        state = initial;

    }

    public void Run()

    {

        Console.CursorVisible = false;

        while (!state.GameOver)

        {

            Draw(state);

            ConsoleKey? key = null;

            if (Console.KeyAvailable)

                key = Console.ReadKey(true).Key;

            state = GameLogic.Update(state, key);

            Thread.Sleep(120);

        }

        Console.SetCursorPosition(0, state.Map.Height + 2);

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("GAME OVER");

        Console.ResetColor();

    }

    void Draw(GameState s)

    {

        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < s.Map.Height; y++)

        {

            for (int x = 0; x < s.Map.Width; x++)

            {

                if (s.Player.X == x && s.Player.Y == y)

                {

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write('P');

                }

                else if (s.Ghost.X == x && s.Ghost.Y == y)

                {

                    Console.ForegroundColor = s.PowerActive

                        ? ConsoleColor.Cyan

                        : ConsoleColor.Red;

                    Console.Write('G');

                }

                else

                {

                    char c = s.Map.Grid[y, x];

                    Console.ForegroundColor = c switch

                    {

                        '#' => ConsoleColor.Blue,

                        '.' => ConsoleColor.Yellow,

                        'o' => ConsoleColor.Magenta,

                        _ => ConsoleColor.White

                    };

                    Console.Write(c);

                }

                Console.ResetColor();

            }

            Console.WriteLine();

        }

        Console.WriteLine($"Score: {s.Score}");

    }

}