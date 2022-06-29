using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float x;
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        //Rigidbody2Dを取得
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //x軸に加わる力を格納
        Vector2 force = new Vector2(x * 10, 0);

        //Rigidbody2Dに力を加える
        rb.AddForce(force);
    }

}
