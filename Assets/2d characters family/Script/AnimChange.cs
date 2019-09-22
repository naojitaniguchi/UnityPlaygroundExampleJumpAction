using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChange : MonoBehaviour
{
    Animator animator;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;

        }
        if (!moving)
        {

            animator.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Front");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Right");
        }
       
    }
}
