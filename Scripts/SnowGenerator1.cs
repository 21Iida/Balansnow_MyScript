using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator1 : MonoBehaviour
{
    [SerializeField] GameObject Player = default;
    Vector3 p_pos = Vector3.zero; //プレイヤーの位置情報
    [SerializeField] GameObject SnowObj1 = default;//落ちてくる雪1
    [SerializeField] GameObject SnowObj2 = default;//落ちてくる雪2
    [SerializeField] float[] Time_Snow1 = {0.5f,0.5f,0.5f}; //タイプ1の雪
    [SerializeField] float[] Time_Snow2 = {0.5f,0.5f,0.5f}; //タイプ2の雪
    float SnowTime = 0;
    
    
    float Rand_X;
    float Snow_Y;

    void Start()
    {
        /*
        InvokeRepeating("SnowFall_L1",0.5f,Time_Snow1[0]);
        InvokeRepeating("SnowFall_M1",0.2f,Time_Snow1[1]);
        InvokeRepeating("SnowFall_R1",0.6f,Time_Snow1[2]);

        InvokeRepeating("SnowFall_L2",0.4f,Time_Snow2[0]);
        InvokeRepeating("SnowFall_M2",0.8f,Time_Snow2[1]);
        InvokeRepeating("SnowFall_R2",0.2f,Time_Snow2[2]);
        */
        //外部から操作を受け付けるために実装を変更
    }

    void Update()
    {
        p_pos = Player.transform.position;
        Snow_Y = p_pos.y + 20;
    }
    void FixedUpdate(){
        SnowTime++;
        SnowGene(SnowTime);
    }

    private void SnowGene(float delta){
        if(delta % 50f == 0)SnowFall_L1();
        if(delta % 20f == 0)SnowFall_M1();
        if(delta % 60f == 0)SnowFall_R1();
        if(delta % 40f == 0)SnowFall_L2();
        if(delta % 80f == 0)SnowFall_M2();
        if(delta % 20f == 0)SnowFall_R2();
    }

    //3分割して少し生成率をいじれるように備えておく
    void SnowFall_L1(){
        Rand_X = (Random.value) * 20 * -1 -4;
        Rand_X += p_pos.x;
        Instantiate(SnowObj1 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }
    void SnowFall_M1(){
        Rand_X = (Random.value - 0.5f) * 8;
        Rand_X += p_pos.x;
        Instantiate(SnowObj1 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }
    void SnowFall_R1(){
        Rand_X = (Random.value) * 20 * 1 +4f;
        Rand_X += p_pos.x;
        Instantiate(SnowObj1 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }

    void SnowFall_L2(){
        Rand_X = (Random.value) * 20 * -1 -4;
        Rand_X += p_pos.x;
        Instantiate(SnowObj2 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }
    void SnowFall_M2(){
        Rand_X = (Random.value - 0.5f) * 8;
        Rand_X += p_pos.x;
        Instantiate(SnowObj2 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }
    void SnowFall_R2(){
        Rand_X = (Random.value) * 20 * 1 +4f;
        Rand_X += p_pos.x;
        Instantiate(SnowObj2 , new Vector3(Rand_X,Snow_Y,0),Quaternion.identity);
    }

}
