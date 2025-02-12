using UnityEngine;

public class GameCtrl : GameMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] private Transform mainCamera;
    public Transform MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only one GameCtrl allow to exist");
        GameCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;

        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}
