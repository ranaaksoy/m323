using System;

class Program

{

    static void Main()

    {

        char[,] grid =

        {

            { '#','#','#','#','#','#','#','#' },

            { '#','.','.','.','.','o','.','#' },

            { '#','.','#','#','.','.','.','#' },

            { '#','.','.','.','.','.','.','#' },

            { '#','#','#','#','#','#','#','#' }

        };

        var map = new Map(grid);

        var state = new GameState(

            map,

            new Position(1, 1),

            new Position(6, 3),

            0,

            false,

            false,

            0

        );

        new Game(state).Run();

    }

}