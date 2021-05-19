using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] TowerSO TSO;
    [SerializeField] Vector2[] BackTilePos;
    [SerializeField] SerializeTowerData[] sTD; // 모든 정보 관리
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Spawn");
            RandomSpawn();
        }
    }

    public void RandomSpawn()
    {
        int RandIndex = Random.Range(0, BackTilePos.Length);
        Vector3 randPos = BackTilePos[RandIndex];
        var obj = ObjectPooler.Inst.SpawnFromPool("tower", randPos, Util.QI).GetComponent<Tile>();
        obj.SetLv(1);

        sTD[RandIndex] = new SerializeTowerData(true, RandIndex, TSO.GetRandomDiceData().code, 1);
    }
}
