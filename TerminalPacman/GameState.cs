// immutable snapshot
public record GameState(

    Map Map,

    Position Player,

    Position Ghost,

    int Score,

    bool GameOver,

    bool PowerActive,

    int PowerTicks

);