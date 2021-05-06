using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public List<Vector3> PlaceList = new List<Vector3>();

    [SerializeField] UnitDatabase UDB;
    [SerializeField] GameObject UnitPrefab;
    public int counting = 0;
    public int max = 15;
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
            if (max == 0)
            {
                AddUnit(false);
            }
            else
                AddUnit(true);
        }
    }

    

    void AddUnit(bool isMine)
    {
        int placeListNum = Random.Range(0, max);
        var unitObject = Instantiate(UnitPrefab, PlaceList[placeListNum], Quaternion.identity);
        PlaceList.RemoveAt(placeListNum);
        var unit = unitObject.GetComponent<Unit>();
        unit.SetUp(SummonUnit());
        Debug.Log("max= "+max);
        max -= 1;
    }



}
