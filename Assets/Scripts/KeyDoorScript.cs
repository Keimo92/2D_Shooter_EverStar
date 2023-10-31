using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorScript : MonoBehaviour
{

    public static KeyDoorScript instance;

    public Transform door;
    public GameObject colliderObj;

    public float openSpeed;

    

    public AudioSource audiosource;

    public AudioClip clip;

    public bool shouldOpen;

 

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (shouldOpen && door.position.z != 1f)
        {
            OpenDoor();
        }
        else if (!shouldOpen && door.position.z != 0f)


        {
           CloseDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
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



    public void OpenDoor()
    {
        door.position = Vector3.MoveTowards(door.position, new Vector3(door.position.x, door.position.y, 1f), openSpeed * Time.deltaTime);


        if (door.position.z == 1f)
        {
            colliderObj.SetActive(false);
        }
    }


    public void CloseDoor()
    {
         door.position = Vector3.MoveTowards(door.position, new Vector3(door.position.x, door.position.y, 0f), openSpeed * Time.deltaTime);

            if (door.position.z == 0f)
            {
                colliderObj.SetActive(true);
            }
    }

}

