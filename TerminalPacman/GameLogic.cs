// functional/pure

using System;

public static class GameLogic
{
    public static GameState Update(GameState state, ConsoleKey? input)
    {
        var player = MovePlayer(state, input);
        var ghost = MoveGhost(state, player);

        bool gameOver = player == state.Ghost;

        int score = state.Score;

        char tile = state.Map.Grid[player.Y, player.X];

        if (tile == '.')
            score++;

        bool powerActive = state.PowerActive;
        int powerTicks = state.PowerTicks;

        if (tile == 'o')
        {
            powerActive = true;
            powerTicks = 20;
        }

        if (powerActive)
        {
            powerTicks--;
            if (powerTicks <= 0)
                powerActive = false;
        }

        return state with
        {
            Player = player,
            Ghost = ghost,
            Score = score,
            GameOver = gameOver,
            PowerActive = powerActive,
            PowerTicks = powerTicks
        };
    }

    static Position MovePlayer(GameState state, ConsoleKey? key)
    {
        var (x, y) = state.Player;

        if (key == null) return state.Player;

        return key switch
        {
            ConsoleKey.UpArrow when !state.Map.IsWall(x, y - 1) => new Position(x, y - 1),
            ConsoleKey.DownArrow when !state.Map.IsWall(x, y + 1) => new Position(x, y + 1),
            ConsoleKey.LeftArrow when !state.Map.IsWall(x - 1, y) => new Position(x - 1, y),
            ConsoleKey.RightArrow when !state.Map.IsWall(x + 1, y) => new Position(x + 1, y),
            _ => state.Player
        };
    }

    static Position MoveGhost(GameState state, Position player)
    {
        var (gx, gy) = state.Ghost;

        int dx = player.X - gx;
        int dy = player.Y - gy;

        int nx = gx;
        int ny = gy;

        if (Math.Abs(dx) > Math.Abs(dy))
            nx += Math.Sign(dx);
        else
            ny += Math.Sign(dy);

        if (!state.Map.IsWall(nx, ny))
            return new Position(nx, ny);

        return state.Ghost;
    }
}