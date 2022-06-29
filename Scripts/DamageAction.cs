using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAction : MonoBehaviour
{
    Rigidbody2D rig2d;
    private float LRint = 1;//左右の判定です。正なら右に、負なら左に飛びます
    private SpriteRenderer[] spRend = default;
    private bool DamageFlag = false;

    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        spRend = gameObject.GetComponentsInChildren<SpriteRenderer> ();
    }

    void Update()
    {
        if(DamageFlag){
            Flashing();
            Invoke("DamageEnd",1.0f); //ここの数値が無敵時間
        }
    }

    private void OnTriggerEnter2D(Collider2D coll){
        //Enemyタグに当たって、なおかつ無敵時間外
        if(coll.CompareTag("Enemy") && DamageFlag == false){
            if(this.transform.position.x < coll.gameObject.transform.position.x){
                LRint = -1;
            } else {
                LRint = 1;
            }
            BoundAction();
            DamageFlag = true;
        }
    }

    //ここで吹っ飛ぶ
    private void BoundAction(){
        rig2d.velocity = Vector3.zero;
        rig2d.AddForce(new Vector2(5 * LRint, 5), ForceMode2D.Impulse);
    }

    //ここで色を点滅
    private void Flashing(){
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            spRend[0].color =  new Color(1f,1f,1f,level);
            spRend[1].color =  new Color(1f,1f,1f,level);
            spRend[2].color =  new Color(1f,1f,1f,level);
    }

    //ダメージ表現の終わり
    private void DamageEnd(){
        DamageFlag = false;
        
            spRend[0].color =  new Color(1f,1f,1f,1);
            spRend[1].color =  new Color(1f,1f,1f,1);
            spRend[2].color =  new Color(1f,1f,1f,1);
    }
}
