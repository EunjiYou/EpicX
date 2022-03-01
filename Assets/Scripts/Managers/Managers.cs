using UnityEngine;

public class Managers : MonoSingleton<Managers> {
    [SerializeField]
    private UnitManager _unitManager = new UnitManager();
    [SerializeField]
    private GameStateManager _gameStateManager = new GameStateManager();
    [SerializeField]
    private DataManager _dataManager = new DataManager();
    
    public static GameStateManager GameState => Instance._gameStateManager;
    public static UnitManager Unit => Instance._unitManager;
    public static DataManager Data => Instance._dataManager;

    private void Awake() {
        DontDestroyOnLoad(this);

        Unit.Init();
        Data.Init();
    }

    private void Update() {
        GameState.Update();
    }
}