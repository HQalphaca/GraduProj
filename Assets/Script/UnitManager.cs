using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Inst { get; private set; }
    private void Awake() => Inst = this;

    List<GameObject> Spawned = new List<GameObject>();

    [SerializeField] UnitDatabase UDB;
    [SerializeField] GameObject UnitPrefab;

    [Range(0, 16)]
    public int x;
    [Range(0, 16)]
    public int y;

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
        {
            AddUnit(true);
        }
    }

    

    void AddUnit(bool isMine)
    {
        int RXL = Random.Range(-2, 3);
        int RYL = Random.Range(-1, 2);
        var unitObject = Instantiate(UnitPrefab, new Vector3(RXL,RYL,0f), Quaternion.identity);
        var unit = unitObject.GetComponent<Unit>();
        unit.SetUp(SummonUnit());
        Spawned.Add(unitObject);
    }

    
}
