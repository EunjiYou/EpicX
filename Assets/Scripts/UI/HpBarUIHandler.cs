using UnityEngine;
using UnityEngine.UI;

public class HpBarUIHandler : MonoBehaviour {
    public UnitStateMachine unitUnitState;
    public Slider hpBar;

    void Start() {
        unitUnitState.stat.onHpValueChanged += () => {
            hpBar.value = unitUnitState.stat.CurHp / (float)unitUnitState.baseStat.maxHp;
        };
    }
}