using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomOnTouch : MonoBehaviour
{

    public GameObject fadeIn;

    public Camera cam;

    public Rigidbody2D rb;

    public float speed = 20;

    public Grid grid;

    


    public void Start()
    {
        
        Animator animator  = GetComponent<Animator>();
        fadeIn.SetActive(false);
    }

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
            fadeIn.SetActive(true);

            Animator animator = GetComponent<Animator>();

            animator.SetTrigger("FadeIn");

            StartCoroutine(LoadScene());

            grid.gameObject.SetActive(false);
            
            cam.fieldOfView = 179;

        }

    }


    //IENumerator to change the scene to endText 
   IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("MainMenu");
    }
}
