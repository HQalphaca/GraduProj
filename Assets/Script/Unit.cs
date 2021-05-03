using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Unit : MonoBehaviour
{
    public enum State
    {
        Move = 0,
        Attack = 1,
        Hit = 2,
        Die = 3
    }

    public enum UnitType
    {
        Shooting,
        Fire,
        Ice,
        Electric,
        Normal,
        Bullet
    };


    private State state = State.Move;
    public UnitType UT;

    public Enemy currentTarget = null;
    private Animator anim;
    private float speed = 1f;
    public int hp=10;
    public float SearchRange;
    public float AttackSpeed = 0.1f;
    public GameObject Bullet = null;
    public Transform BulletStartTrans;
    public bool isMove = true;
    





    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Start()
    {
        StartCoroutine(CheckTarget());
        StartCoroutine(CheckAttack());
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
        if (isMove == true) {
            anim.SetBool("isAttack",false);
            Move();
        }
    }

    private void FixedUpdate()
    {

    }

    private void Move()
    {
        if (state != State.Move)
            return;
        anim.SetBool("isMove", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void SearchR()
    {
        switch (UT)
        {
            case UnitType.Normal:
                SearchRange = 0.5f;
                break;
            case UnitType.Shooting:
                SearchRange = 2f;
                break;
            case UnitType.Fire:
                SearchRange = 0.5f;
                break;
            case UnitType.Ice:
                SearchRange = 0.5f;
                break;
            case UnitType.Electric:
                SearchRange = 0.5f;
                break;
        }

    }

    private IEnumerator CheckTarget()
    {
        while (true)
        {
            switch (UT)
            {
                case UnitType.Shooting:
                    {
                        SearchR();
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
                    break;
                case UnitType.Normal:
                    {
                        SearchR();
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
                    break;
                case UnitType.Fire:
                    {
                        SearchR();
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
                    break;
                case UnitType.Ice:
                    {
                        SearchR();
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
                    break;
                case UnitType.Electric:
                    {
                        SearchR();
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
                    break;
            }
        }
    }


    private bool CoroutineWait()
    {
        return currentTarget == null;
    }

    private IEnumerator CheckAttack()
    {
        while (true)
        {
            if (currentTarget != null)
            {
                Attack();
                yield return new WaitForSeconds(AttackSpeed);
            }
            else
            {
                yield return new WaitWhile(CoroutineWait);
            }
        }
    }



    private void Attack()
    {
        isMove = false;
        anim.SetBool("isAttack",true);
        anim.SetBool("isMove", false);
        switch (UT)
        {
            case UnitType.Normal:
                break;
            case UnitType.Shooting:
                GameObject obj = Instantiate(Bullet);
                obj.transform.position = BulletStartTrans.position;
                Bullet script = obj.GetComponent<Bullet>();
                script.SetTarget(currentTarget, 1f);
                break;
            case UnitType.Fire:
                break;
            case UnitType.Ice:
                break;
            case UnitType.Electric:
                break;

        }

    }
}
