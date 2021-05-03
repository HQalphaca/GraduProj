using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] UnitDatabase UDB;

    List<UnitDB> statBuffer;
    public UnitDB SummonUnit()
    {
        if (statBuffer.Count == 0)
            SetupStatBuffer();
        UnitDB unitDB = statBuffer[0];
        statBuffer.RemoveAt(0);
        return unitDB;
    }
    void SetupStatBuffer()
    {
        statBuffer = new List<UnitDB>();
        for(int i = 0; i < UDB.udb.Length; i++)
        {
            UnitDB unitDB = UDB.udb[i];
            for(int j = 0; j < unitDB.percent; j++)
            {
                statBuffer.Add(unitDB);
            }
        }
        for(int i = 0; i < statBuffer.Count; i++)
        {
            int rand = Random.Range(i, statBuffer.Count);
            UnitDB temp = statBuffer[i];
            statBuffer[i] = statBuffer[rand];
            statBuffer[rand] = temp;
        }
    }

    void Start()
    {
        SetupStatBuffer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(SummonUnit().name);
    }
}
