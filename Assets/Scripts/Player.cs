using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    SpriteRenderer spriteRend;
    Animator anim;

    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        anim.SetBool("isMoving", false);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            anim.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteRend.flipX = true;
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            anim.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
            anim.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteRend.flipX = false;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            anim.SetBool("isMoving", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Attack()
    {

    }

}
