using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour
{

    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    public Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
    }

    void Update()
    {
        CheckKey();
        gameObject.transform.eulerAngles = rot;
    }

    void CheckKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk_Anim", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walk_Anim", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rot[1] -= rotSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rot[1] += rotSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!anim.GetBool("Open_Anim"))
            {
                anim.SetBool("Open_Anim", true);
            }
            else
            {
                anim.SetBool("Open_Anim", false);
            }
        }
    }
}
