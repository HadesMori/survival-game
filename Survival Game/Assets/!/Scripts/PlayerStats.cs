using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatType
{
    MaxHP,
    CurrentHP,
    Speed,
    Damage,
    AttackSpeed,
    HealthRegen,
}

public class PlayerStats : MonoBehaviour
{
    public CharacterStat MaxHP = new CharacterStat(0);
    public CharacterStat CurrentHP = new CharacterStat(0);
    public CharacterStat Speed = new CharacterStat(0);
    public CharacterStat Damage = new CharacterStat(0);
    public CharacterStat AttackSpeed = new CharacterStat(0);
    public CharacterStat HealthRegen = new CharacterStat(0);

    public List<CharacterStat> Stats;

    private void Start()
    {
        Stats.Add(MaxHP);
        Stats.Add(CurrentHP);
        Stats.Add(Speed);
        Stats.Add(Damage);
        Stats.Add(AttackSpeed);
        Stats.Add(HealthRegen);
    }
}
