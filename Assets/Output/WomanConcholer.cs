using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanConcholer : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [Header("移动参数")]
    public float maxSpeed;
    private float horizontalAcceration = 5f;
    private float horizontalDeceleration = 5f;
    private float horizontalMove;
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
        AnimConchol();
    }
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1

        if ((horizontalMove != 0))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, horizontalAcceration * Time.deltaTime);
            transform.localScale = new Vector3(horizontalMove, 1, 1);
           // AudioManager.instance.PlaySound("Feet",transform.position);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, horizontalDeceleration * Time.deltaTime);
        }
        //rb.velocity = new Vector2(horizontalMove * currentSpeed, rb.velocity.y);

        rb.velocity = new Vector2(currentSpeed * transform.localScale.x, rb.velocity.y);

    }
    void AnimConchol()
    {
        if (currentSpeed != 0)
        {
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

}
