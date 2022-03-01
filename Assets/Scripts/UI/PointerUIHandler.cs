using UnityEngine;
using UnityEngine.UI;

public class PointerUIHandler : MonoBehaviour {
    public UnitStateMachine unitStateMachine;
    public Image pointerImage;
    
    void Update() {
        if (unitStateMachine.State is UnitState.ReadyToAttack or UnitState.Attack) {
            pointerImage.gameObject.SetActive(true);
        }
        else {
            pointerImage.gameObject.SetActive(false);
        }
    }
}