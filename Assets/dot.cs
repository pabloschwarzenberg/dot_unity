using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    float speed = 2.0f;
    bool isOnGround;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    void OnCollisionStay()
    {
        isOnGround = true;
        anim.SetBool("jumping", false);
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float step;
        float x, y, z;

        if(isOnGround)
        {
            if (xInput != 0 || yInput != 0)
            {
                step = speed * Time.deltaTime;
                anim.SetBool("walking", true);
                x = Mathf.Max(transform.position.x + (xInput * step),0.0f);
                y = transform.position.y;
                z = Mathf.Clamp(transform.position.z + (yInput * step), -0.4f, 0.4f);
                transform.position = new Vector3(x, y, z);
            }
            if (xInput == 0 && yInput == 0)
            {
                anim.SetBool("walking", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0.0f, 4.0f, 0.0f), ForceMode.Impulse);
                anim.SetBool("walking", false);
                anim.SetBool("jumping", true);
                isOnGround = false;
            }
        }
        else
        {
            if (xInput != 0)
            {
                rb.AddForce(new Vector3(1.0f, 0.0f, 0.0f), ForceMode.Impulse);
            }
        }
        if(xInput<0)
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else if(xInput>0)
            transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}