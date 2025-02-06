using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected Transform bulletPrefab;

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.shooting) return;

        Instantiate(this.bulletPrefab);
        Debug.Log("Shooting");
    }
}
