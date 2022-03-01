using System.Linq;
using Random = UnityEngine.Random;

public class EnemyUnitStateMachine : UnitStateMachine {
    protected override void OnStateChanged() {
        base.OnStateChanged();
        
        switch (State) {
            case UnitState.ReadyToAttack:
                State = UnitState.Attack;
                break;
            case UnitState.Attack:
                AttackRandomCharacter();
                break;
        }
    }

    private void AttackRandomCharacter() {
        var activeTargets = Managers.Unit.units
            .Where(character => UnitType.Enemy != character.unitType && UnitState.Dead != character.State)
            .Select(character => character.unitId).ToArray();
    
        var targetIdx = Random.Range(0, activeTargets.Count());
        Managers.GameState.attackInfos.Add(new AttackInfo() {
            attackUnitId = unitId, 
            targetUnitId = activeTargets[targetIdx]
        });
    }
}