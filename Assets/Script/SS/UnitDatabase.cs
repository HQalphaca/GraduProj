using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitDB
{
    public string name;
    public Sprite sprite;
    public float AttackRange;
    public int AttackDamage;
    public float AttackSpeed;
    public int CriticalDamage;
    public float CriticalChance;
    public int percent;
}


[CreateAssetMenu(fileName ="UnitDatabase",menuName ="Scriptable Object/UnitDatabase")]
public class UnitDatabase:ScriptableObject
{
    public UnitDB[] udb;
}
