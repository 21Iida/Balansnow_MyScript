// 沈む氷山のスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMove : MonoBehaviour
{
    public float downSpeed;    // 沈んでいく速さ
    public float upSpeed;      // 上昇する速さ
    public float moveSpeed;    // 氷山が移動するスピード
    private float moveReg = 0.0f;     // 氷山が移動するスピードの一時記憶
    private bool MoveFlag; // 氷山が動くフラグ
    public float destinyX;  // 目的地のx座標

    private void Start()
    {
        MoveFlag = false;
    }

    private void Update()
    {
        // プレイヤーが接触したらmoveSpeedで動き出す
        if (MoveFlag)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * 0.001f, transform.position.y, 0);
        }
        // 目的地に着いたら沈みだす
        if (destinyX <= transform.position.x)
        {
            MoveFlag = false;
            transform.position = new Vector3(destinyX, transform.position.y - downSpeed * 0.001f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("Player");
            MoveFlag = true;
        }
    }

    // 氷山との接触
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 自分が右の氷山に接触したとき
        if (collision.gameObject.tag == "Hyozan" && this.transform.position.x < collision.transform.position.x)
        {
            DownFlag = true;
        }

        // 自分が左の氷山に接触されたとき
        if (collision.gameObject.tag == "Hyozan" && collision.transform.position.x < this.transform.position.x)
        {
            UpFlag = true;
        }
    }
    */

    // 氷山と離れた時
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        UpFlag = false;
    }
    */
    

}