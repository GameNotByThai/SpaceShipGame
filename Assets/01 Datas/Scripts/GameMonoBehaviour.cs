using UnityEngine;

public class GameMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void OnEnable()
    {
        //For override
    }

    protected virtual void OnDisable()
    {
        //For override
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        //For override
    }

    protected virtual void LoadComponent()
    {
        //For override
    }
}
