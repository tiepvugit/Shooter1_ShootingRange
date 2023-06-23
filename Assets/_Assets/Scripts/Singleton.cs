using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var inScenceInstance = FindObjectOfType<T>();
                RegisterInstance(inScenceInstance);
            }
            else if (_instance != FindObjectOfType<T>())
            {
                Destroy(FindObjectOfType<T>());
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            RegisterInstance((T)(MonoBehaviour)this);
            Init();
        }
        else if(_instance != this)
        {
            Destroy(this);
        }
    }

    protected virtual void Init()
    {
        Debug.Log("override this method to add some stuff in the initiation!");
    }

    private static void RegisterInstance(T newInstance)
    {
        if (newInstance == null)
        {
            return;
        }
        _instance = newInstance;
        DontDestroyOnLoad(newInstance.gameObject);
    }
}