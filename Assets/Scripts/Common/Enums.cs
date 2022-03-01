
public enum GameState {
    Ready,
    Start,
    TurnStart,
    TurnPerformed,
    TurnEnd,
    End
}

public enum GameResult {
    None,
    Win,
    Lose,
    Draw
}

public enum UnitType {
    Tanker,
    Dealer,
    Enemy
}

public enum UnitState {
    Idle,
    ReadyToAttack,
    Attack,
    Dead
}