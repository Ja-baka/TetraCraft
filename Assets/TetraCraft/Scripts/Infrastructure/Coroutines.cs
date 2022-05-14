using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines _instance;

    private static Coroutines Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject(nameof(Coroutines));
                _instance = gameObject.AddComponent<Coroutines>();
                DontDestroyOnLoad(gameObject);
            }
            return _instance;
        }
    }

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return Instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            Instance.StopCoroutine(routine);
        }
    }
}
