using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Enemy : MonoBehaviour
{
    // 변수 설정.
    public int _hp;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    public Sprite[] sprites;
    public bool isMove = true;
    private float speed = 1f;
    UnitManager unitManager;
    public int killedGold = 10;
    public GameObject dmgText;
    public Transform dmgPos;
    public SpawnManager sm;

    public event System.Action OnDeath;


    // 각 변수들을 사용하기 위한 변수 받아옴.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        unitManager=GameObject.Find("UnitManager").GetComponent<UnitManager>();
    }

    // 유닛 움직임 감지.
    public void Update()
    {
        if (isMove == true)
        {
            Move();
        }
    }

    // 피격시 데미지를 받으며, 받은 데미지 표시.
    public void OnHit(int dmg)
    {
        
        _hp -= dmg;
        GameObject dmgtxt = Instantiate(dmgText);
        dmgtxt.transform.position = dmgPos.position;
        dmgtxt.GetComponent<PrintDmg>().damage = dmg;
        spriteRenderer.sprite = sprites[0];
        Invoke("Return",0.1f);
        if (_hp <= 0)
        {
            Die();
            unitManager.Gold += 10;
            unitManager.GoldText.text = "현재 골드: " + unitManager.Gold;
        }
    }

    // 유닛 움직임 설정 함수.
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
    // 유닛 사망시 설정.
    public void Die()
    {
        OnDeath?.Invoke();
        Destroy(this.gameObject);
    }
    // 유닛 피격후 돌아올때의 이미지 설정.
    void Return()
    {
        spriteRenderer.sprite = sprites[1];
    }
    // 유닛이 총알과 충돌시 일어나는 이벤트 설정.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            isMove = false;
            OnHit(bullet.attackdamage);   
        }
    }
}