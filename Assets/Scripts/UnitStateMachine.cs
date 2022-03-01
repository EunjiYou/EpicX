using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct UnitBaseStat {
    public int curSpeed;
    public Action onHpValueChanged;
    public int curHp;
    public int CurHp {
        get => curHp;
        set {
            curHp = value;
            if (null != onHpValueChanged) {
                onHpValueChanged.Invoke();
            }
        }
    }
    public int curAtk;
    public int curDef;
}

public class UnitStateMachine : MonoBehaviour {
    public int unitId;
    public UnitType unitType;
    public UnitData baseStat;
    public UnitBaseStat stat;
        
    [SerializeField]
    private UnitState _state;
    public UnitState State {
        get => _state;
        set {
            _state = value;
            OnStateChanged();
        }
    }
    
    protected virtual void OnStateChanged() {
        switch (State) {
            case UnitState.Dead:
                gameObject.SetActive(false);
                Managers.Unit.RemoveUnitFromGame(this);
                break;
        }
    }
    
    public void Start() {
        baseStat = Managers.Data.unitDataByType[unitType];
        
        Init();
    }

    public void Init() {
        stat.curSpeed = baseStat.baseSpeed + Random.Range(1, 10);
        stat.CurHp = baseStat.maxHp;
        stat.curAtk = baseStat.baseAtk;
        stat.curDef = baseStat.baseDef;
    }

    public void Damage(int damage) {
        var realDamage = Mathf.Max(0, damage - stat.curDef);
        stat.CurHp = Mathf.Max(0, stat.CurHp - realDamage);
        if (0 >= stat.CurHp) {
            State = UnitState.Dead;
        }
    }
}