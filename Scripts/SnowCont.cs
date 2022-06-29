using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCont : MonoBehaviour
{
    [SerializeField] float SnowSpeed = -0.1f; //落ちる速度
    [SerializeField] float SinSpeed = 10; //ゆれる速度
    [SerializeField] float SinRadious = 0.05f; //ゆれる幅
    [SerializeField] float Snow_x = 0; //x軸への移動
    [SerializeField] float DeadLine = 0;    // 雪が死ぬ高さ
    float SnowPong = 0;
    float delta = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        delta += Time.deltaTime * SinSpeed;
        SnowPong = Mathf.Sin(delta) * SinRadious;
        SnowPong += Snow_x;

        transform.Translate( SnowPong ,SnowSpeed,0);

        //雪死亡判定
        if(this.transform.position.y < DeadLine){
            Destroy(this.gameObject);
            //時間がないのでオブジェクトプール作ってないです
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
