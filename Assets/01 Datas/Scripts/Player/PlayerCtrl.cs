using UnityEngine;
public class PlayerCtrl : GameMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] protected ShipCtrl curentShip;
    public ShipCtrl CurentShip => curentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;
    public PlayerAbility PlayerAbility => playerAbility;


    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPickup();
        this.LoadPlayerAbility();
    }
    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;

        this.playerPickup = GetComponentInChildren<PlayerPickup>();
        Debug.LogWarning(transform.name + ": LoadPlayerPickup", gameObject);
    }

    protected virtual void LoadPlayerAbility()
    {
        if (this.playerAbility != null) return;

        this.playerAbility = GetComponentInChildren<PlayerAbility>();
        Debug.LogWarning(transform.name + ": LoadPlayerAbility", gameObject);
    }
}
