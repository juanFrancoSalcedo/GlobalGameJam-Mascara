using System;

public class LifeModel
{
    public int hp;
    public Action onDead;

    public LifeModel(int hp, Action onDead)
    {
        this.hp = hp;
        this.onDead = onDead;
    }

    public void MakeDamageBase()
    {
        hp --;
        CheckDead();
    }

    public void MakeDamage(int amount)
    {
        hp -= amount;
        CheckDead();
    }

    public bool IsDead => hp <=0;
    public bool CheckDead() 
    {
        if (IsDead)
        {
            onDead?.Invoke();
            return true;
        }
        return false;
    }
}
