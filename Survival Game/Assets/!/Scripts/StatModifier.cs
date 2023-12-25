public enum StatModifierType
{
    Flat,
    Percent,
}

[System.Serializable]
public class StatModifier
{
    public float Value;
    public StatModifierType Type;
    public readonly int Order;

    public StatModifier(float value, StatModifierType type, int order)
    {
        Value = value;
        Type = type;
        Order = order;
    }

    public StatModifier(float value, StatModifierType type) : this(value, type, (int)type) { }
}
