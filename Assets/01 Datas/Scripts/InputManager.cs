using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    [SerializeField] private Vector3 mouseWorldPos;

    public static InputManager Instance { get => instance; }
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only one InputManager allow to exist");
        InputManager.instance = this;
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
