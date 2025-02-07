using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected float shootDelay = 0.5f;
    [SerializeField] protected float shootTimer = 0;

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (IsDelayTime()) return;

        if (!IsShooting()) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne1, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);

        Debug.Log("Shooting");
    }

    protected virtual bool IsDelayTime()
    {
        return shootTimer < shootDelay;
    }

    protected virtual bool IsShooting()
    {
        return InputManager.Instance.OnFiring == 1;
    }
}
