using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;
    public float jumpforce;
    private Rigidbody2D rig;
    private Animator anim;
    public bool isJumping;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Jump();
       dash();
       Crouch();
       ataque2();
       ataque3();
    }

    void Move()
    {
        anim.SetBool("crouch", false);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        // sequência de condicionais para checar se o personagem está se movendo e animar tal movimento.
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        // rotação de personagem para a animação ficar para a esquerda
        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walk", false);
        }
        
    }

    void Jump()
    {
        anim.SetBool("crouch", false);
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
            
        }
    }

    void dash()
    {
        anim.SetBool("crouch", false);
        if(Input.GetButtonDown("W"))
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
                rig.AddForce(new Vector2(10f, 0f), ForceMode2D.Impulse);
                anim.SetBool("dash", true);
            }
            if(Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
                rig.AddForce(new Vector2(-10f, 0f), ForceMode2D.Impulse);
                anim.SetBool("dash", true);
            }
            
        } 
    }

    void ataque2()
    {
        anim.SetBool("crouch", false);
        if(Input.GetButtonDown("Q"))
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
                anim.SetBool("viegoatk2", true);
            }
            if(Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
                anim.SetBool("viegoatk2", true);
            }
        }
    }

    void ataque3()
    {
        anim.SetBool("crouch", false);
        if(Input.GetButtonDown("E"))
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0f,0f,0f);
                anim.SetBool("viegoatk3", true);
            }
            if(Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
                anim.SetBool("viegoatk3", true);
            }
        }
    }
    
    
    void Crouch()
    {
        if(Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("crouch", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void EndAnimation()
    {
        anim.SetBool("dash", false);
        anim.SetBool("viegoatk2", false);
        anim.SetBool("viegoatk3", false);
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

}
