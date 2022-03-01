using UnityEngine;
using UnityEngine.UI;

public class IngameHud : MonoBehaviour {
    public Text resultText;
    public Button skill1Button;
    
    public void OnSkill1ButtonClick() {
        Managers.GameState.attackInfos.Add(new AttackInfo() {
            attackUnitId = Managers.GameState.CurrentTurnUnit.unitId, 
            targetUnitId = Managers.GameState.Enemy.unitId
        });
    }
    
    public void OnGameStartButtonClick() {
        Managers.GameState.State = GameState.Start;
    }

    public void Update() {
        switch (Managers.GameState.State) {
            case GameState.End:
                resultText.gameObject.SetActive(true);
                resultText.text = $"You {Managers.GameState.gameResult}!";
                break;
            case GameState.TurnStart:
            case GameState.TurnPerformed:
            case GameState.TurnEnd:
                bool isUnitsTurn = UnitType.Enemy != Managers.GameState.CurrentTurnUnit.unitType;
                skill1Button.gameObject.SetActive(isUnitsTurn);
                break;
            default:
                resultText.gameObject.SetActive(false);
                break;
        }
    }
}