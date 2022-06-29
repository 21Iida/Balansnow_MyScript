using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSnowGenerator : MonoBehaviour
{
    [SerializeField] SnowGenerator1 s_g;

    void Start()
    {
        s_g = GameObject.Find("SnowDirector").GetComponent<SnowGenerator1>();

    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.CompareTag("NoSnowArea")){
            s_g.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("NoSnowArea")){
           
            s_g.enabled = true;
        }
    }
}
