using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 150.0f;
    public float speed = 1.0f;
    private float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool moving; 
  

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (moveDirection != 0)
        {
            _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
            moving = false;
        }
        /*if(_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
            

        }*/
        else  {moving = true; }

        
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }
    void Update()
    {
        if (grounded == true ) {
           if(Input.GetKey(KeyCode.A)) { 
                moveDirection = -1.0f; 
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed",1.00f);
            }
           else if (Input.GetKey(KeyCode.D)){ 
                moveDirection = 1.0f; 
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", 1.00f);
            }
            else if (moving == false) {
                moveDirection = 0.0f;
                anim.SetFloat("speed", 0.0f);
            }
        }
        if (grounded == true && Input.GetKey(KeyCode.W)){
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin")) /// yer Objelerini unity üzerinden zemin olarak tagledik
        {
            grounded = true;
            anim.SetBool("grounded", true);
        }

    }

}
