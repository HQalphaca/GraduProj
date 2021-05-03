using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private Enemy _target;
    private float _time;
    private float _progress = 0f;
    private Vector2 _startPos;
    
    
    public void SetTarget(Enemy target,float time)
    {
        _target = target;
        _time = time;
        _progress = 0;
        _startPos = this.transform.position;
        StartCoroutine(Move());
    }
    
    private IEnumerator Move()
    {
        Vector2 targetPos = _target.transform.position;
        while (_progress <= 1f)
        {
            transform.position = Vector2.Lerp(_startPos, targetPos, _progress);
            _progress += Time.deltaTime / _time;

            if (_target != null)
            {
                targetPos = _target.transform.position;
            }
            yield return null;
        }

        if (_target != null)
        {
            _target.OnHit(damage);
        }
        Destroy(this.gameObject);
    }
}
