using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public bool isAttacking;
    public bool isParrying;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        isAttacking = anim.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        isParrying = anim.GetCurrentAnimatorStateInfo(0).IsName("Parry");

        if (horizontalAxis > 0 && !isAttacking && !isParrying)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("Walk", true);
        }
        else if (horizontalAxis < 0 && !isAttacking && !isParrying)
        {

            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
            transform.localScale = new Vector3(-1, 1, 1);
            //Debug.Log("flip x");
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

    }

    

   
}
