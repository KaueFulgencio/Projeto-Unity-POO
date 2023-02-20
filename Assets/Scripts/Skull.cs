using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            health--;
            if (health <= 0)
                Destroy(gameObject);
            collision.GetComponent<Sword>().CreateParticle();
            Destroy(collision.gameObject);
        }
    }
}
