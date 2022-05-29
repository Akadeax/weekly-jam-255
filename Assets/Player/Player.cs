using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    float currentSize = 1.5f;

    [SerializeField]
    float suckPower = 1f;

    SpriteRenderer spriteRend;
    Animator anim;

    [SerializeField]
    LayerMask anthills;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    int facing = 1;
    void Update()
    {

        Vector3 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        if (movement.x > 0) facing = 1;
        else if (movement.x < 0) facing = -1;
        transform.localScale = new Vector3(currentSize * facing, currentSize);

        anim.SetBool("isSucking", Input.GetKey(KeyCode.Space));
        anim.SetBool("isMoving", movement.sqrMagnitude != 0);

        if (Input.GetKey(KeyCode.Space))
        {
            anim.speed = suckPower;
            RaycastHit2D anthill = Physics2D.Raycast(transform.position, Vector2.right, transform.localScale.x, anthills);
            Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x);
            if (anthill.collider != null)
            {
                Anthill hitHill = anthill.collider.gameObject.GetComponent<Anthill>();
                hitHill.GettingSucked();
            }
        }
        else
        {
            // Apply movement
            transform.position += movement * Time.deltaTime;

            // Set animation speed based on how fast player is moving
            anim.speed = movement.magnitude / 5 / currentSize;
        }
    }



    bool stepOne = true;
    public void StepEvent()
    {
        // basing step sound pitch on animator speed is very satisfying
        stepOne = !stepOne;
        SFXManager.PlaySFX("anteaterStep" + (stepOne ? "1" : "2"), anim.speed);
    }

}
