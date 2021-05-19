using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Value")]
    [SerializeField] Transform[] lvVisual;
    [SerializeField] UnitDatabase TDB;
    [SerializeField] int level; // 1~6

    public void SetupTile(UnitDatabase TDB)
    {
        this.TDB = TDB;
        spriteRenderer.sprite = TDB.UnitImg;
    }

    public void SetLv(int level)
    {
        for(int i = 0; i < Util.T_LEVEL; i++)
        {
            if (i < level)
            {
                lvVisual[i].gameObject.SetActive(i<level);
            }
        }
        //위치 설정
        Vector2[] lvpos=new Vector2[1];
        switch (level)
        {
            case 1:
                lvpos = new Vector2[] { Vector2.zero };
                break;
            case 2:
                lvpos = new Vector2[] { new Vector2(-0.16f,-0.16f), new Vector2(0.16f, 0.16f) };
                break;
            case 3:
                lvpos = new Vector2[] { new Vector2(-0.16f, -0.16f), new Vector2(0.16f, 0.16f), Vector2.zero };
                break;
            case 4:
                lvpos = new Vector2[] { new Vector2(-0.16f, -0.16f), new Vector2(0.16f, 0.16f), new Vector2(-0.16f, 0.16f), new Vector2(0.16f, -0.16f) };
                break;
            case 5:
                lvpos = new Vector2[] { new Vector2(-0.16f, -0.16f), new Vector2(0.16f, 0.16f), new Vector2(-0.16f, 0.16f), new Vector2(0.16f, -0.16f),Vector2.zero };
                break;
            case 6:
                lvpos = new Vector2[] { new Vector2(-0.16f, -0.16f), new Vector2(0.16f, 0.16f), new Vector2(-0.16f, 0.16f), new Vector2(0.16f, -0.16f), new Vector2(0.16f, 0f), new Vector2(-0.16f, 0f) };
                break;
        }
        for(int i = 0; i < lvpos.Length; i++)
        {
            lvVisual[i].localPosition = lvpos[i];
        }
    }
}
