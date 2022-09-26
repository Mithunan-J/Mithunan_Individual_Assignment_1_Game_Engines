using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            HealthManager.instance.ChangeHealth(-10f);
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
        }
    }

}
