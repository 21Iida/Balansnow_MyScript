using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turningPoint : MonoBehaviour
{
    private GameObject controller;  // コントローラースクリプトをとってくる
    
    public float lowerLimit;  // 下限の設定
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.transform.localScale.x <= lowerLimit) 
        {
            //ゲームオーバー処理
            Debug.Log("GameOver");
            gameOver = true;
            collision.GetComponent<Controller>().enabled = false;
        }
    }
}
