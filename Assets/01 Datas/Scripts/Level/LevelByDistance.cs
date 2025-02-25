using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distaince")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 70f;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    public virtual void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }

    private void Leveling()
    {
        if (this.target == null) return;

        this.distance = Vector3.Distance(transform.position, this.target.position);
        int newLevel = this.GetLevelByDistance();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(this.distance / distancePerLevel);
    }
}
