using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PrintDmg : MonoBehaviour // 해당 함수는 유닛이 피격시 받는 데미지를 텍스트로 표기해 줌
{
    // 변수 설정
    private float speed;
    private float alphaspeed;
    private float destroyTime;
    public TextMeshPro text;
    public Color alpha;
    public int damage;

    private void Start()
    {
        speed = 1.6f; 
        alphaspeed = 1.6f;
        destroyTime = 1.0f;

        // 텍스트를 표기하는데 필요한 함수
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    void Update()
    {
        // 텍스트가 위로 이동
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

        // 텍스트가 일정 이상 위로 올라갈 시 투명해짐
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaspeed);
        text.color=alpha;
    }

    // 필요없는 메모리 삭제를 위한 텍스트 오브젝트 삭제
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
