using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    private bool facingRight = true;

    //public AnimatorControl animatiorControl;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private AudioSource audioSource;

    [SerializeField]private AudioClip[] audiosClip;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //BONECO ATACA
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isAtk", false);
        }
        else
        {
            anim.SetBool("isAtk", true);
        }
        //BONECO DESLIZA
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("isSlidin", false);
        }
        else
        {
            anim.SetBool("isSlidin", true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        float moveInput = Input.GetAxis("Horizontal");
        float moveInputD = Input.GetAxis("Vertical");

        //UTILIZA O FLIP PARA VIRAR O PINGUIN DE LADO
        if(moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = moveDirection * speed;
        
        //ANIMAÇÃO DO PINGUIN ANDANDO
        if(moveInput == 0 && moveInputD == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }
    //UTILIZADO PARA TROCAR O LADO QUE O PINGUIN ESTÁ OLHANDO
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //FUNÇÃO NECESSARIA PARA O SOM DOS PASSOS, UTILIZA A MATRIZ AudioClip[]
    private void Passos()
    {
        audioSource.PlayOneShot(audiosClip[Random.Range(0, audiosClip.Length)]);
    }
}
