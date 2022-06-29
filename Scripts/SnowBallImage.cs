using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallImage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool isNotRotation = true; // 回転するか否か
    public float alpha; // 画像のアルファ値(0なら完全に透明)

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTransparency(); // 完全に透明にする
    }

    void ChangeTransparency()
    {
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
    }
    private void Update()
    {
        // 回転させたくないとき
        if (isNotRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
       
    }
}
