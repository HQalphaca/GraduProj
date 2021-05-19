using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


// 스크립터블 오브젝트를 통해 각 변수를 오브젝트에 삽입
// enum을 통해 각 항목별 변수를 넣어줄수 있도록 함.
public enum UnitNum
{
    Unit1, Unit2, Unit3, Unit4, Unit5
}



public class UnitManager : MonoBehaviour // 유닛을 관리하는 클래스 함수.
{
    // 스크립터블 오브젝트를 받아오기 위한 설정.
    public static UnitManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public List<Vector3> PlaceList = new List<Vector3>();

    [SerializeField]
    public List<UnitDatabase> unitdata;
    [SerializeField] 
    GameObject UnitPrefab;

    // 변수 설정.
    UnitNum unitNum;
    public int counting = 0;
    public int MAX = 15;
    public int Gold = 200;
    public int GoldForSpawn = 30;
    public int UpgradeGold1=20;
    public int UpgradeGold2=20;
    public int UpgradeGold3=20;
    public int UpgradeGold4=20;
    public int UpgradeGold5=20;

    public GameObject Bullet_1;
    public GameObject Bullet_2;
    public GameObject Bullet_3;
    public GameObject Bullet_4;
    public GameObject Bullet_5;

    public Unit unit;

    // 텍스트 변수 설정.
    #region txt
    public Text GoldText;
    public Text GoldForSpawnText;
    public Text UpgradeText1;
    public Text UpgradeText2;
    public Text UpgradeText3;
    public Text UpgradeText4;
    public Text UpgradeText5;
    public Text UpgradeGoldText1;
    public Text UpgradeGoldText2;
    public Text UpgradeGoldText3;
    public Text UpgradeGoldText4;
    public Text UpgradeGoldText5;
    #endregion



    
    // 초기 텍스트 설정.
    void Start()
    {
        GoldText.text = "현재 골드: " + Gold;
        GoldForSpawnText.text ="" + GoldForSpawn;
        #region txtSetting
        UpgradeText1.text = "1";
        UpgradeText2.text = "2";
        UpgradeText3.text = "3";
        UpgradeText4.text = "4";
        UpgradeText5.text = "5";
        UpgradeGoldText1.text = "" + UpgradeGold1;
        UpgradeGoldText2.text = "" + UpgradeGold2;
        UpgradeGoldText3.text = "" + UpgradeGold3;
        UpgradeGoldText4.text = "" + UpgradeGold4;
        UpgradeGoldText5.text = "" + UpgradeGold5;
        #endregion
    }

    void Update()
    {

    }

    // enum의 항목들을 랜덤으로 섞어 유닛에 변수 삽입.
    public void SpawnUnit()
    {
        int SpawnRand = Random.Range(0, 5);
        AddUnit((UnitNum)SpawnRand);

    }

    // 유닛 업그레이드 함수.
    public void Upgrade1()
    {
        if (Gold >= UpgradeGold1)
        {
            Gold -= UpgradeGold1;
            UpgradeGold1 += 10;
            UpgradeGoldText1.text = "" + UpgradeGold1;
            GoldText.text = "현재 골드: " + Gold;
            Bullet_1.GetComponent<Bullet>().attackdamage++; 
            Debug.Log("Upgrade");
        }
        else if (Gold < UpgradeGold1)
        {
            Debug.Log("Can't Upgrade");
        }
        if (UpgradeGold1 >= 70)
        {
            GameObject.Find("Upgrade1").SetActive(false);
            Debug.Log("Upgrade Finish");
        }
    }
    public void Upgrade2()
    {
        if (Gold >= UpgradeGold2)
        {
            Gold -= UpgradeGold2;
            UpgradeGold2 += 10;
            UpgradeGoldText2.text = "" + UpgradeGold2;
            GoldText.text = "현재 골드: " + Gold;
            Bullet_2.GetComponent<Bullet>().attackdamage++;
            Debug.Log("Upgrade");
        }
        else if (Gold < UpgradeGold2)
        {
            Debug.Log("Can't Upgrade");
        }
        if (UpgradeGold2 >= 70)
        {
            GameObject.Find("Upgrade2").SetActive(false);
            Debug.Log("Upgrade Finish");
        }
    }
    public void Upgrade3()
    {
        if (Gold >= UpgradeGold3)
        {
            Gold -= UpgradeGold3;
            UpgradeGold3 += 10;
            UpgradeGoldText3.text = "" + UpgradeGold3;
            GoldText.text = "현재 골드: " + Gold; 
            Bullet_3.GetComponent<Bullet>().attackdamage++;
            Debug.Log("Upgrade");
        }
        else if (Gold < UpgradeGold3)
        {
            Debug.Log("Can't Upgrade");
        }
        if (UpgradeGold3 >= 70)
        {
            GameObject.Find("Upgrade3").SetActive(false);
            Debug.Log("Upgrade Finish");
        }
    }
    public void Upgrade4()
    {
        if (Gold >= UpgradeGold4)
        {
            Gold -= UpgradeGold4;
            UpgradeGold4 += 10;
            UpgradeGoldText4.text = "" + UpgradeGold4;
            GoldText.text = "현재 골드: " + Gold;
            Bullet_4.GetComponent<Bullet>().attackdamage++;
            Debug.Log("Upgrade");
        }
        else if (Gold < UpgradeGold4)
        {
            Debug.Log("Can't Upgrade");
        }
        if (UpgradeGold4 >= 70)
        {
            GameObject.Find("Upgrade4").SetActive(false);
            Debug.Log("Upgrade Finish");
        }
    }
    public void Upgrade5()
    {
        if (Gold >= UpgradeGold1)
        {
            Gold -= UpgradeGold5;
            UpgradeGold5 += 10;
            UpgradeGoldText5.text = "" + UpgradeGold5;
            GoldText.text = "현재 골드: " + Gold; 
            Bullet_5.GetComponent<Bullet>().attackdamage++;
            Debug.Log("Upgrade");
        }
        else if (Gold < UpgradeGold5)
        {
            Debug.Log("Can't Upgrade");
        }
        if (UpgradeGold5 == 70)
        {
            GameObject.Find("Upgrade5").SetActive(false);
            Debug.Log("Upgrade Finish");
        }
    }

    // 유닛 추가를 위한 생성할 게임 오브젝트 설정 및 다른 이벤트 발생시 행동 설정.
    public Unit AddUnit(UnitNum type)
    {
        if (MAX > 0 && Gold >= GoldForSpawn)
        {
            int placeListNum = Random.Range(0, MAX);
            var unitObject = Instantiate(UnitPrefab, PlaceList[placeListNum], Quaternion.identity).GetComponent<Unit>();
            PlaceList.RemoveAt(placeListNum);
            unitObject.UnitData = unitdata[(int)type];
            Debug.Log("max= " + MAX);
            MAX -= 1;
            Gold -= GoldForSpawn;
            GoldForSpawn += 10;
            GoldText.text = "현재 골드: " + Gold;
            GoldForSpawnText.text = "" + GoldForSpawn;

            return unitObject;
        }
        else if (MAX <= 0)
        {
            Debug.Log("지금은 소환 불가능 합니다.");

            return null;
        }
        else if(Gold < GoldForSpawn)
        {
            Debug.Log("돈이 부족합니다.");
            return null;
        }

        return null;
    }

    // 게임 종료 후 재시작시 업그레이드 된 데미지 초기화를 위함 함수.
    private void OnApplicationQuit()
    {
        Bullet_1.GetComponent<Bullet>().attackdamage = UnitDatabase.Inst.Damage;
        Bullet_2.GetComponent<Bullet>().attackdamage = UnitDatabase.Inst.Damage;
        Bullet_3.GetComponent<Bullet>().attackdamage = UnitDatabase.Inst.Damage;
        Bullet_4.GetComponent<Bullet>().attackdamage = UnitDatabase.Inst.Damage;
        Bullet_5.GetComponent<Bullet>().attackdamage = UnitDatabase.Inst.Damage;
    }
}
