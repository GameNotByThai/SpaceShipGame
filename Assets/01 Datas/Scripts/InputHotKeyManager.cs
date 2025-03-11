using UnityEngine;

public class InputHotKeyManager : MonoBehaviour
{
    private static InputHotKeyManager instance;
    public static InputHotKeyManager Instance => instance;

    public bool isAlpha1 = false;
    public bool isAlpha2 = false;
    public bool isAlpha3 = false;
    public bool isAlpha4 = false;
    public bool isAlpha5 = false;
    public bool isAlpha6 = false;
    public bool isAlpha7 = false;

    private void Awake()
    {
        if (InputHotKeyManager.instance != null) Debug.LogError("Only one InputHotKeyManager allow to exist");
        InputHotKeyManager.instance = this;
    }

    private void Update()
    {
        this.GetHotKeyPress();
    }

    protected virtual void GetHotKeyPress()
    {
        isAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        isAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        isAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        isAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        isAlpha5 = Input.GetKeyDown(KeyCode.Alpha5);
        isAlpha6 = Input.GetKeyDown(KeyCode.Alpha6);
        isAlpha7 = Input.GetKeyDown(KeyCode.Alpha7);
    }



}
