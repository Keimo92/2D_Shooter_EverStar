using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoPickUp : MonoBehaviour
{
    public static AmmoPickUp instance;

    public int ammunition = 10;

  

    public AudioSource audiosource;

    public AudioClip clip;

    


    // Start is called before the first frame update
    void Awake()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    // Trigger collision which gets the player instance from PlayerMovement to add ammo from the AmmoPickUp script // WORK WITH THIS FIRST BEFORE CONTINUE
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            PlayerMovement.instance.ammoCount += ammunition;

            AmmoPickUp ammo = GetComponent<AmmoPickUp>();

            ammo.enabled = false;

            Debug.Log("Here is ammo");
            audiosource.PlayOneShot(clip);
            Destroy(gameObject, 0.5f);



        }
    }
}
    
       
    
   

