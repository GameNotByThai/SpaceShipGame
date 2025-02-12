using UnityEngine;

public class ParentFly : GameMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1.0f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
