using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float health;
    public float maxhealth;
    public float thrusPower;
    public float cooldownTime = 0.5f;
    
    private float lastPressTime;
    private bool facingRight = true;

    public GameObject sword;
    
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private AudioSource audioSource;
    [SerializeField]private AudioClip[] audiosClip;

    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maxhealth = health;
       
    }

    void Update()
    {
        Move();
        
    }
    void Move()
    {
        //if (!canMove) { return; }

        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //BONECO ATACA
        if (Input.GetKey(KeyCode.Space))
        {
            //Attack();
            //anim.SetBool("isAtk", false);
            if (Time.time >= lastPressTime + cooldownTime)
            {
                Attack();
                anim.SetBool("isAtk", false);
                lastPressTime = Time.time;
            }
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
    void Attack()
    {
        //canMove = false;

        GameObject newSword = Instantiate(sword, transform.position, transform.rotation);
        float swordDir = Input.GetAxis("Horizontal");
        float swordDire = Input.GetAxis("Vertical");

        //W
        if(swordDire == -1) //S
        {
            newSword.transform.Rotate(0, 0, -180);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrusPower);
        }
        else if (swordDire == 1) //D = -90
        {
            newSword.transform.Rotate(0, 0, 0);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrusPower);
        }

        else if(swordDir == 0)  // A
        {
            newSword.transform.Rotate(0, 0, 0);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrusPower);
        }
        else if (swordDir == 1)  // A
        {
            newSword.transform.Rotate(0, 0, -90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrusPower);
        }
        else if(swordDir == -1) // A
        {
            newSword.transform.Rotate(0, 0, 90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrusPower);
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
