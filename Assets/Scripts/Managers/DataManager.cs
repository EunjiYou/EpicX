using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataManager {
    [SerializeField]
    private List<UnitData> unitDatas;

    public Dictionary<UnitType, UnitData> unitDataByType = new Dictionary<UnitType, UnitData>();
    
    public void Init() {
        foreach (var unitData in unitDatas) {
            unitDataByType[unitData.unitType] = unitData;
        }
    }
}