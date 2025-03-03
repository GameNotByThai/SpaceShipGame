using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectAppear : GameMonoBehaviour
{
    [Header("Object Appear")]
    [SerializeField] protected bool isAppearing = false;
    public bool IsAppearing => isAppearing;

    [SerializeField] protected bool appeared = false;
    public bool Appeared => appeared;

    [SerializeField] protected List<IObjectAppearObserver> observers = new List<IObjectAppearObserver>();

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObserver observer in observers)
        {
            observer.OnAppearStart();
        }
    }
    protected virtual void OnAppearFinish()
    {
        foreach (IObjectAppearObserver observer in observers)
        {
            observer.OnAppearFinish();
        }
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    public virtual void AddObserver(IObjectAppearObserver objectAppearObserver)
    {
        this.observers.Add(objectAppearObserver);
    }
}
