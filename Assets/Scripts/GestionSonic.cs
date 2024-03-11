using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSonic : MonoBehaviour
{

    public float vitesseDeplacement;
    public float forceSaut;

    // Private (Non definissable dans l'inspecteur) Private juste quand ce sont des variables pour leur script uniquement (Si besoin d'interagir avec autres scripts, public)
    private Vector2 velocitePersonnage;
    private bool newJump = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            print("d appuyer");
            GetComponent<SpriteRenderer>().flipX = false;

            GetComponent<Animator>().SetBool("Marche", true);
            velocitePersonnage.x = vitesseDeplacement;

        } else if (Input.GetKey(KeyCode.A)) 
        {
            print("a appuyer");
            GetComponent<SpriteRenderer>().flipX = true;

            GetComponent<Animator>().SetBool("Marche", true);
            velocitePersonnage.x = -vitesseDeplacement;
        } else
        {

            GetComponent<Animator>().SetBool("Marche", false);
            velocitePersonnage.x = GetComponent<Rigidbody2D>().velocity.x; // Valeur calculer par l'engin (Qui de-accelere grace au drag)
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (newJump)
            {
                velocitePersonnage.y = forceSaut;
                newJump = false;
            }
        } else
        {
            velocitePersonnage.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = velocitePersonnage;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        newJump = true;
    }
}
