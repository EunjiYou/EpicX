using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Object/UnitData")]
public class UnitData : ScriptableObject {
    public UnitType unitType;
    public int baseSpeed;
    public int maxHp;
    public int baseAtk;
    public int baseDef;

    public Sprite unitImage;
    public Color unitColor;
}