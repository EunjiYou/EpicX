using UnityEngine;
using UnityEngine.UI;

public class UnitInfoHud : MonoBehaviour {
    public Image unitImage;
    public Text unitNameText;
    public Text unitHpText;
    public Slider unitHpBar;
    
    void Update() {
        if (Managers.GameState.State is GameState.Ready or GameState.End) {
            return;
        }

        var unit = Managers.GameState.CurrentTurnUnit;
        unitNameText.text = unit.unitType.ToString();
        unitHpText.text = $"{unit.stat.CurHp.ToString()}/{unit.baseStat.maxHp.ToString()}";
        unitHpBar.value = unit.stat.CurHp / (float)(unit.baseStat.maxHp);

        unitImage.sprite = Managers.Data.unitDataByType[unit.unitType].unitImage;
        unitImage.color  = Managers.Data.unitDataByType[unit.unitType].unitColor;
    }
}