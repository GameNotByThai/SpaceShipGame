using UnityEngine;

public class GameMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        //For override
    }
}
