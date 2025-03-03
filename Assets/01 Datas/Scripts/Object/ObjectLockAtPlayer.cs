using UnityEngine;
public class ObjectLockAtPlayer : ObjectLockAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected GameObject player;
    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        base.FixedUpdate();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;

        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void GetPlayerPosition()
    {
        if (this.player == null) return;

        this.targetPos = this.player.transform.position;
        this.targetPos.z = 0;
    }
}
