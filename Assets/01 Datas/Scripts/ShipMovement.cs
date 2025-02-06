using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPos;
    [SerializeField] protected float shipSpeed = 0.1f;

    private void FixedUpdate()
    {
        this.worldPos = InputManager.instance.mouseWorldPos;
        this.worldPos.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.worldPos, shipSpeed);
        transform.parent.position = newPos;
    }
}
