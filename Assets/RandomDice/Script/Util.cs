using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeTowerData
{
    public bool isFull;
    public int index;
    public int code;
    public int level;

    public SerializeTowerData(bool isFull, int index, int code, int level)
    {
        this.isFull = isFull;
        this.index = index;
        this.code = code;
        this.level = level;
    }
}

public class Util
{
    public const int T_LEVEL = 6;

    public static readonly Quaternion QI = Quaternion.identity;
}
