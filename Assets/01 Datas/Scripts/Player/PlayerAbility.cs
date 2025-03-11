using UnityEngine;

public class PlayerAbility : GameMonoBehaviour
{
    public virtual void Active(AbilityCode abilityCode)
    {
        Debug.Log("Ability Code: " + abilityCode.ToString());
    }
}
