using System;
using UnityEngine;
public enum AbilityCode
{
    NoAbility = 0,

    Missile = 1,
    Laze = 2,
}

public class AbilityCodeParser
{
    public static AbilityCode FromString(string abilityName)
    {
        try
        {
            return (AbilityCode)System.Enum.Parse(typeof(AbilityCode), abilityName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilityCode.NoAbility;
        }
    }
}