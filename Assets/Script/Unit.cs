using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;


public class Unit : MonoBehaviour
{
    // 스크립터블 오브젝트를 받기 위한 설정.
    [SerializeField] UnitDatabase unitDatabase;
    public UnitDatabase UnitData { set { unitDatabase = value; } }
    public static Unit Inst { get; private set; }
    private void Awake() => Inst = this;
    bool isEnemy;


    // 변수 설정.
    [SerializeField]
    public List<UnitDatabase> unitdata;
    [SerializeField]
    GameObject BulletPrefab;


    public Enemy currentTarget = null;
    private Animator anim;
    public float SearchRange =5.0f;
    public float AttackSpeed = 0.1f;
    public int damage;
    public Transform BulletStartTrans;
    public bool isMove = true;
    public UnitManager unitManager;
    public SpriteRenderer unitSprite;
    public Sprite unitImg;
    public static Unit AttackDamage;
    public Bullet bullet;


    // 스크립터블 오브젝트의 값들을 받아오며, 실행할 함수들 실행
    public void Start()
    {
        StartCoroutine(CheckTarget());
        StartCoroutine(CheckAttack());
        damage = unitDatabase.Damage;
        unitSprite = gameObject.GetComponent<SpriteRenderer>();
        unitImg = unitDatabase.unitImg;
        unitSprite.sprite = unitImg;
    }

    // 유닛 탐색시 유닛이 없으면 근처에 유닛 없다고 표기.
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


    // 스크립터블 오브젝트에서 데미지 받아옴.
    private void FixedUpdate()
    {
        damage = unitDatabase.Damage;
    }

    // 공격 범위 받아옴.
    private float SearchR()
    {
        SearchRange = unitDatabase.attackRange;
        return SearchRange;
    }

    // 공격 속도 받아옴.
    private float AttackSpd()
    {
        AttackSpeed = unitDatabase.AttackSpeed;
        return AttackSpeed;
    }

    // 콜라이더를 통해 특정 레이어가 충돌시 충돌된 오브젝트를 배열로 저장.(공격할 타겟 설정)
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
                    break;
                }
            }
            yield return new WaitUntil(CoroutineWait);
            yield return null;
        }
    }

    // 공격할 타겟이 없을시 대기.
    private bool CoroutineWait()
    {
        return currentTarget == null;
    }

    // 공격할 타겟 공격.
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



    // 적 유닛 공격을 위한 총알 프리팹 생성 함수.
    private void Attack()
    {
        BulletPrefab = unitDatabase.bulletPrefab;
        GameObject obj = Instantiate(BulletPrefab);
        obj.transform.position = BulletStartTrans.position;
        Bullet script = obj.GetComponent<Bullet>();
        script.SetTarget(currentTarget, 1f);
    }
}
