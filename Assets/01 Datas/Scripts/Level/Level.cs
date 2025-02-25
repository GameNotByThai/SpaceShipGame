using UnityEngine;

public class Level : GameMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int maxLevel = 99;
    public int CurrentLevel => currentLevel;
    public int MaxLevel => maxLevel;

    public virtual void LevelUp()
    {
        this.currentLevel++;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.currentLevel = newLevel;
        this.LimitLevel();
    }

    private void LimitLevel()
    {
        if (this.currentLevel > maxLevel) this.currentLevel = maxLevel;
        if (this.currentLevel < 1) this.currentLevel = 1;
    }
}
