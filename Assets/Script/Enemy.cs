using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Enemy : MonoBehaviour
{
    public int _hp;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Rigidbody2D rigid;
    public Sprite[] sprites;
    public bool isMove = true;
    private float speed = 1f;
    public enum State
    {
        Move = 0,
        Attack = 1,
        Hit = 2,
        Die = 3
    }
    private State state = State.Move;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (isMove == true)
        {
            anim.SetBool("isMove", true);
            anim.SetBool("isAttack", false);
            Move();
        }
    }

    public void OnHit(int dmg)
    {
        _hp -= dmg;
        spriteRenderer.sprite = sprites[0];
        Invoke("Return",0.2f);
        if (_hp <= 0)
        {
            Die();
        }
    }
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
    void Return()
    {
        spriteRenderer.sprite = sprites[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            isMove = false;
            anim.SetBool("isHit", true);
            OnHit(bullet.damage);   
        }
    }
}