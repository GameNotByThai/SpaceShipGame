using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos => mouseWorldPos;

    [SerializeField] private float onFiring = 0;
    public float OnFiring => onFiring;

    private Vector4 direction;
    public Vector4 Direction => direction;

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
        this.GetDirectionByKeyDown();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (this.direction.x == 0)
            this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 0)
            this.direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 0)
            this.direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.w == 0)
            this.direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;

        //if (this.direction.x == 1) Debug.Log("LEFT");
        //if (this.direction.y == 1) Debug.Log("RIGHT");
        //if (this.direction.z == 1) Debug.Log("UP");
        //if (this.direction.w == 1) Debug.Log("DOWN");
    }
}
