using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform door;
    public GameObject colObj;

    public float openSpeed;


    public AudioSource audiosource;

    public AudioClip clip;

    private bool shouldOpen;



    private void Update()
    {
        if (shouldOpen && door.position.z != 1f)
        {
            door.position = Vector3.MoveTowards(door.position, new Vector3(door.position.x, door.position.y, 1f), openSpeed * Time.deltaTime);


            if (door.position.z == 1f)
            {
                colObj.SetActive(false);
            }
        }
        else if (!shouldOpen && door.position.z != 0f)


        {
            door.position = Vector3.MoveTowards(door.position, new Vector3(door.position.x, door.position.y, 0f), openSpeed * Time.deltaTime);

            if (door.position.z == 0f)
            {
                colObj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            audiosource.PlayOneShot(clip);
            shouldOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
          
            shouldOpen = false;
        }
    }
}
