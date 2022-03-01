using System;
using System.Collections.Generic;

[Serializable]
public class UnitManager {
    public List<UnitStateMachine> ingameUnits = new List<UnitStateMachine>();
    public List<UnitStateMachine> units = new List<UnitStateMachine>();

    private static int _unitCount = 0;
    public void Init() {
        foreach(var character in units) {
            character.unitId = _unitCount++;
        }
    }
    
    public void SortUnitsBySpeed() {
        ingameUnits.AddRange(units);
        ingameUnits.Sort((lState, rState) => rState.stat.curSpeed.CompareTo(lState.stat.curSpeed));
    }

    public void RemoveUnitFromGame(UnitStateMachine unit) {
        ingameUnits.Remove(unit);
    }
}