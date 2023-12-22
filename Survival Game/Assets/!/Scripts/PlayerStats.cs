using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat MaxHP = new CharacterStat(0);
    public CharacterStat CurrentHP = new CharacterStat(0);
    public CharacterStat Speed = new CharacterStat(0);
    public CharacterStat Damage = new CharacterStat(0);
    public CharacterStat AttackSpeed = new CharacterStat(0);
}
