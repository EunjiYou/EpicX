using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component {
    private static T _instance;

    public static T Instance {
        get {
            if (null == _instance) {
                _instance = FindObjectOfType<T>();
                if (null == _instance) {
                    var go = new GameObject();
                    _instance = go.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
}

public class Singleton {
    protected Singleton() {
    }

    private static Singleton _instance;

    public static Singleton Instance {
        get {
            if (null == _instance) {
                _instance = new Singleton();
            }

            return _instance;
        }
    }
}