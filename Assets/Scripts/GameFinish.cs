using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnTouch : MonoBehaviour
{

    public Camera cam;

    public Rigidbody2D rb;

    public float speed = 20;

    public Grid grid;

    private void Update()
    {
       if(cam.fieldOfView >178)
        {
            rb.transform.Rotate(0f, 1f, 0f, Space.Self);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            grid.gameObject.SetActive(false);
            
            cam.fieldOfView = 179;

        }

    }



   
}
