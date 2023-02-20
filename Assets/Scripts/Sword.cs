using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float timer = .60f;

    public GameObject swordParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject.FindGameObjectWithTag("weapon").GetComponent<PlayerControl>();
            Destroy(gameObject);
        }
    }

    public void CreateParticle()
    {
        Instantiate(swordParticle, transform.position, transform.rotation);
    }
}
