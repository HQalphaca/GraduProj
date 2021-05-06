using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;


public class Unit : MonoBehaviour
{
    [SerializeField] SpriteRenderer unitImg;

    bool isEnemy;

    public Enemy currentTarget = null;
    private Animator anim;
    private float speed = 1f;
    public int hp=10;
    public float SearchRange;
    public float AttackSpeed = 0.1f;
    public int damage;
    public GameObject Bullet = null;
    public Transform BulletStartTrans;
    public bool isMove = true;
    public UnitDB unitdb;

    public static Unit AttackDamage;
    
    public void SetUp(UnitDB unitdb)
    {
        this.unitdb = unitdb;
        unitImg.sprite = this.unitdb.sprite;
    }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        AttackDamage = this;
    }
    public void Start()
    {
        StartCoroutine(CheckTarget());
        StartCoroutine(CheckAttack());
        damage = unitdb.AttackDamage;
    }


    public void Update()
    {
        if (currentTarget != null)
        {
            if (Vector2.Distance(currentTarget.transform.position, this.transform.position) > SearchRange)
            {
                currentTarget = null;
            }
        }
    }

    private void FixedUpdate()
    {

    }

    private void SearchR()
    {
        SearchRange = unitdb.AttackRange;
    }
    private float AttackSpd()
    {
        AttackSpeed = unitdb.AttackSpeed;
        return AttackSpeed;
    }


    private IEnumerator CheckTarget()
    {
        while (true)
        {
            SearchR();
            AttackSpd();
            int layerMask = 1 << LayerMask.NameToLayer("Enemy");
            Collider2D[] objs = Physics2D.OverlapCircleAll(transform.position, SearchRange, layerMask);

            foreach (Collider2D item in objs)
            {
                Enemy target = item.GetComponent<Enemy>();
                if (target != null)
                {
                    currentTarget = target;
                    Debug.Log("Searched");
                    break;
                }
            }
            yield return new WaitUntil(CoroutineWait);
            yield return null;
        }
    }


    private bool CoroutineWait()
    {
        return currentTarget == null;
    }

    private IEnumerator CheckAttack()
    {
        AttackSpd();
        while (true)
        {
            if (currentTarget != null)
            {
                Attack();
                yield return new WaitForSeconds(AttackSpd());
            }
            else
            {
                yield return new WaitWhile(CoroutineWait);
            }
        }
    }



    private void Attack()
    {
        GameObject obj = Instantiate(Bullet);
        obj.transform.position = BulletStartTrans.position;
        Bullet script = obj.GetComponent<Bullet>();
        script.SetTarget(currentTarget, 1f);
    }
}
