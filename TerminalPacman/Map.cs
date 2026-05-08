// immutable logic
public class Map

{

    public char[,] Grid { get; }

    public int Width => Grid.GetLength(1);

    public int Height => Grid.GetLength(0);

    public Map(char[,] grid)

    {

        Grid = grid;

    }

    public bool IsWall(int x, int y)

        => Grid[y, x] == '#';

}