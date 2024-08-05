using UnityEngine;

public abstract class StatHandler
{
    protected float _value;

    public virtual float Value
    {
        get => _value;
        set => _value = Validate(value);
    }

    protected abstract float Validate(float value);
}

public class HealthStatHandler : StatHandler
{
    public float MaxHealth;

    public HealthStatHandler(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    protected override float Validate(float value)
    {
        return Mathf.Clamp(value, 0, MaxHealth);
    }
}

public class PercentageStatHandler : StatHandler
{
    protected override float Validate(float value)
    {
        return Mathf.Clamp(value, 0, 1);
    }
}

public class SimpleStatHandler : StatHandler
{
    protected override float Validate(float value)
    {
        return value;
    }
}
