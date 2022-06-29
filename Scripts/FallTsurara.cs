using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTsurara : MonoBehaviour
{
    [SerializeField] private GameObject Player = default;
    private bool FallFlag = false;
    private bool YureFlag = false;
    private float p_dis = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        p_dis = Player.transform.position.x - this.transform.position.x;
        p_dis = Mathf.Abs(p_dis);

        if(p_dis < 2f){
            FallFlag = true;
        } else
        if(p_dis < 7){
            YureFlag = true;
        } else
        {
            YureFlag = false;
        }

        if(FallFlag){
            YureFlag = false;
            transform.Translate(0, 0.05f, 0);
        }
        if(YureFlag){
            transform.Translate(Mathf.Sin(Time.time * 50) * 0.1f,0,0);
        }

        if(transform.position.y > 20){
            Destroy(this.gameObject);
        }

    }
}
