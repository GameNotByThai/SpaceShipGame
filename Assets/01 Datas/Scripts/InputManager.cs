using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    [SerializeField] private Vector3 mouseWorldPos;

    [SerializeField] private float onFiring = 0;

    public static InputManager Instance { get => instance; }
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only one InputManager allow to exist");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }

    protected virtual void GetMouseDown()
    {
        //Get left mouse down
        this.onFiring = Input.GetAxis("Fire1");
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
