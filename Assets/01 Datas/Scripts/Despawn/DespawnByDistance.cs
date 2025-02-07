using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.mainCamera.position);
        if (this.distance > disLimit) return true;
        return false;
    }
}
