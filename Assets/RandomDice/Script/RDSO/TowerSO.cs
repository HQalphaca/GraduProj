using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class TowerData
{
    public int code;
    public Sprite sprite;
    public Color color;
}

[CreateAssetMenu(fileName = "RDSO", menuName = "Scriptable Object/TowerSO")]
public class TowerSO : ScriptableObject
{
    public TowerData[] towerDatas;

    public TowerData GetTowerData(int code) => Array.Find(towerDatas, x => x.code == code);

    public TowerData GetRandomDiceData() => towerDatas[UnityEngine.Random.Range(0, towerDatas.Length)];
}
