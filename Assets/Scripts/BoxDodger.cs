using UnityEngine;

public class DodgerAttributes
{
    private int currentHealth;
    private int maxHealth;
    private int currentScore;


    public DodgerAttributes(int currentHealth, int maxHealth, int currentScore)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.currentScore = currentScore;
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
public void SetScore(int value)
    {
        currentScore = value;
    }
public void SetHealth(int value)
    {
        currentHealth = value;
    }

}