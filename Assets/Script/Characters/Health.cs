using System;

public class Health 
{
    private const float MinHealth = 0f;
    public float Current { get; private set; }
    public float Max { get; private set; }

    public float Ratio => Current / Max;
    public bool IsDead => Current <= MinHealth;
    public bool IsFull => Current >= Max;
    public Health(float max)
    {
        Max = max;
        Current = max;
    }
    public void TakeDamage(float amount)
    {
        Current = Math.Max(MinHealth, Current - amount);
    }

    public void Heal(float amount)
    {
        Current = Math.Min(Max, Current + amount);
    }
}
