using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed  = 1.0f;
        const float moveJump = 10.0f; 

        Vector3 v = rb.velocity;
        if(UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        else if(UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }
        if(UnityEngine.Input.GetKey(KeyCode.Space))
        {
            v.y = moveJump;
        }
        rb.velocity = v;
    }
}
