using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
    }*/
    bool hasPackage;
    [SerializeField] float delay=1f; 
    void OnTriggerEnter2D(Collider2D collision) {
        //if (tag is packageicecream)
        //then print(picked up the package icecream to console
        if(collision.CompareTag("Packageicecream") && !hasPackage)
        {
            Debug.Log("Picked up packageicecream");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject,delay);
        }

        if(collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("delivered package");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
        }
   
}
}
