using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public GameObject door;
   






    public void Start()
    {

        door.gameObject.GetComponent<BoxCollider2D>().enabled = false;

       
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {

       
        if(collision.gameObject.tag == "Player")
        {


            door.gameObject.GetComponent<BoxCollider2D>().enabled = true;

            Debug.Log("You picked up a " + name);

            Destroy(gameObject);
            
        }
    }

   


}
