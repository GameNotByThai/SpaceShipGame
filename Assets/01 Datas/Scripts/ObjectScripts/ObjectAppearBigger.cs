using UnityEngine;
public class ObjectAppearBigger : ObjectAppear
{
    [Header("Object Appear Bigger")]
    [SerializeField] protected float currentScale = 0;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected float speedToScale = 0.01f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }

    protected virtual void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
    }
    protected override void Appearing()
    {
        this.currentScale += this.speedToScale;
        transform.parent.localScale = Vector3.one * this.currentScale;
        if (this.currentScale > this.maxScale) this.Appear();
    }

    public override void Appear()
    {
        base.Appear();
        transform.parent.localScale = Vector3.one * this.maxScale;
    }
}
