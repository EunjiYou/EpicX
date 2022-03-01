using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct AttackInfo {
    public int attackUnitId;
    public int targetUnitId;
}

[Serializable]
public class GameStateManager {
    [SerializeField]
    private GameState _state = GameState.Ready;
    public GameState State {
        get { return _state; }
        set {
            _state = value;
            OnGameStateChanged();
        }
    }

    public UnitStateMachine CurrentTurnUnit => Managers.Unit.ingameUnits[_turn];
    public UnitStateMachine Enemy => Managers.Unit.units[2];  // fixed index

    public List<AttackInfo> attackInfos;
    public GameResult gameResult;
    private int _turn = 0;
    private void OnGameStateChanged() {
        switch (State) {
            case GameState.Start:
                Managers.Unit.SortUnitsBySpeed();
                State = GameState.TurnStart;
                break;
            case GameState.TurnStart:
                CurrentTurnUnit.State = UnitState.ReadyToAttack;
                State = GameState.TurnPerformed;
                break;
            case GameState.TurnEnd:
                OnGameStateTurnEnd();
                break;
            case GameState.End:
                break;
        }
    }

    private void OnGameStateTurnEnd() {
        if (CheckGameEnd()) {
            State = GameState.End;
        }
        else {
            if (Managers.Unit.ingameUnits.Count <= ++_turn) {
                _turn = 0;
            }
                    
            State = GameState.TurnStart;
        }
    }
    
    private bool CheckGameEnd() {
        if (!Managers.Unit.units.Any(character => character.unitType is not UnitType.Enemy
                                                 && character.State is not UnitState.Dead)) {
            gameResult = GameResult.Lose;
            return true;
        }

        if (!Managers.Unit.units.Any(enemy => enemy.unitType is UnitType.Enemy 
                                             && enemy.State is not UnitState.Dead)) {
            gameResult = GameResult.Win;
            return true;
        }

        return false;
    }

    public void Update() {
        if (State is not GameState.TurnPerformed || !attackInfos.Any()) {
            return;
        }
        
        var actionInfo = attackInfos[0];
        var attackUnit = Managers.Unit.units[actionInfo.attackUnitId]; 
        var targetUnit = Managers.Unit.units[actionInfo.targetUnitId]; 
        targetUnit.Damage(attackUnit.stat.curAtk);

        attackUnit.State = UnitState.Idle;
        
        Managers.GameState.State = GameState.TurnEnd;

        attackInfos.Remove(actionInfo);
    }
}