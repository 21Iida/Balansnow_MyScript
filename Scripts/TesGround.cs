using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesGround : MonoBehaviour
{
    [SerializeField] GameObject PlayerPos; //プレイヤー
    float delta = 0; //sin用の時間
    //float p_mag = 0; //プレイヤーとの距離測定
    float Rota_size = 0.03f; //係数
    //Vector2 newAngle = new Vector2(10,0);
    Vector3 rotationAngles = Vector3.zero; //実際に傾ける角度
    float maxRota = 5; //最大の傾き

    void Start()
    {
        
    }

    void Update()
    {
        rotationAngles = transform.rotation.eulerAngles;
        if(rotationAngles.z > 180){
            rotationAngles.z -= 360;
        }

        //p_mag = PlayerPos.transform.position.x - this.transform.position.x;
        //プレイヤーとの距離を測定して揺れの大きさを計算

        if(PlayerPos.transform.position.x > this.transform.position.x){
            rotationAngles.z -= Rota_size;
        } else {
            rotationAngles.z += Rota_size;
        }

        
        Debug.Log("local:" + transform.localRotation.eulerAngles);

        //角度の制限をつける
        if(rotationAngles.z > maxRota){
            rotationAngles.z = maxRota;
        }
        if(rotationAngles.z < -1 * maxRota){
            rotationAngles.z = -1 * maxRota;
        }
        
        //全体を通してかかるsin波
        delta += Time.deltaTime * 10;
        rotationAngles.z += Mathf.Sin(delta) * 0.05f;

        transform.rotation = Quaternion.Euler(rotationAngles);
    }
}
