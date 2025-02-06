using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPos;
    [SerializeField] protected float shipSpeed = 0.1f;

    private void FixedUpdate()
    {
        this.worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.worldPos.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, this.worldPos, shipSpeed);
        transform.position = newPos;
    }
}
