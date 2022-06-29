using UnityEngine;
using System.Collections;

public class GyroController : MonoBehaviour
{

    public float speed;
    //public float jump;

    public Vector3 acceleration;
    private Quaternion gyro;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Input.gyro.enabled = true;
    }

    void FixedUpdate()
    {
        this.acceleration = Input.acceleration;
        this.gyro = Input.gyro.attitude;



        Vector3 movement = new Vector3(this.acceleration.x, 0.0f, 0.0f);
        rb.AddForce(movement * speed);
        Physics.gravity = new Vector3(0, -9.8f, 0);

        /*if (this.acceleration.z > 0.5)
        {
            Vector3 movement_jump = new Vector3(0.0f, 2.0f, 0.0f);
            rb.AddForce(movement_jump * jump * (this.acceleration.z * 5.0f));
        }*/
    }
}