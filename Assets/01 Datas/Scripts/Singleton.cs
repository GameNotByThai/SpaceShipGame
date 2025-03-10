using UnityEngine;

public class Singleton<T> : GameMonoBehaviour where T : GameMonoBehaviour
{
    private static T instance;

    public static T _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
            }

            if (instance == null)
            {
                GameObject obj = new GameObject();
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }
}