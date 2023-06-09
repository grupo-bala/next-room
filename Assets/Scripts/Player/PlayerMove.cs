using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 12.0f;
    
    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0.0f, z);

        if (move != Vector3.zero) {
            this.animator.SetBool("isWalking", true);
        } else {
            this.animator.SetBool("isWalking", false);
        }

        this.transform.Translate(move * this.speed * Time.deltaTime);
    }
}
