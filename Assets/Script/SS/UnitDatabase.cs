using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


[CreateAssetMenu(fileName ="UnitDatabase",menuName ="Scriptable Object/UnitDB")]
public class UnitDatabase:ScriptableObject // 해당 클래스는 유니티 내 오브젝트를 상속 받은 클래스로 시리얼라이즈 시스템 보유, 
                                           // 클래스나 오브젝트를 스트링 or 일차원 배열형태로 변환
{
    public static UnitDatabase Inst { get; private set; }

    [SerializeField]        
    public string UnitName;
    public string unitName { get { return UnitName; } } // 유닛의 이름을 받는 시리얼라이즈 필드

    [SerializeField]
    public int Damage;
    public int damage { get { return Damage; } } // 유닛의 데미지를 표시하는 시리얼라이즈 필드

    [SerializeField]
    public float AttackSpeed;
    public float attackSpeed { get { return AttackSpeed; } } // 유닛의 공격속도를 표시하는 시리얼라이즈 필드

    [SerializeField]
    public float AttackRange;
    public float attackRange { get { return AttackRange; } } // 유닛의 공격범위를 표시하는 시리얼라이즈 필드

    [SerializeField]
    public Sprite UnitImg;
    public Sprite unitImg { get { return UnitImg; } } // 유닛의 이미지를 표현할 수 있는 시리얼 라이즈 필드

    [SerializeField]
    public GameObject bulletPrefab;
    public GameObject bulletPf { get { return bulletPrefab; } } // 유닛이 발사할 총알을 받는 시리얼라이즈 필드


}
