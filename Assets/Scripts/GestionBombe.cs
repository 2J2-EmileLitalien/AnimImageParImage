using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBombe : MonoBehaviour
{
    // Detection sol (Collision) 
    // Jouer animation de l'explosion
    // Enlever la bombe 

    private void OnCollisionEnter2D(Collision2D collisionAvec)
    {
        if (collisionAvec.gameObject.name == "gazon")
        {
            print("Collision detecter");
            GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Velocity X et Y (Vector2) devient zero ( Shortcut a new Vector2(0,0) )
            Invoke("DisparaitreBombe", 0.3f);
        }
    }


    void DisparaitreBombe ()
    {
        Destroy(gameObject);
    }
 
    
}
