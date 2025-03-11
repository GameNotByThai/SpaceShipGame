using UnityEngine;

public class PressableAbliity : Pressable
{
    [SerializeField] protected AbilityCode ability;
    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}
