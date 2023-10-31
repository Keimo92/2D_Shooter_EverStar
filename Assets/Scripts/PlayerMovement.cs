using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private CoolDownTimer cooldown;

    public static PlayerMovement instance;

    public int damage = 20;

    public Rigidbody2D rb;

    public float speed = 5f;


    public Text ammoText;


    public Animator animator;

    private Vector2 moveInput;

    private Vector2 mouseInput;

    public Camera viewCam;

    public GameObject bulletImpact;


    public GameObject text;
  

    public int ammoCount;

   

    public AudioSource audiosource;

    public AudioClip gunEmpty;

  

    public AudioClip clip;
    float maxAngle = 160;
    float minAngle = 10;

    public bool hasDied;

    private void Awake()
    {
        instance = this;
    }

    public float mouseSensitivity = 1f;
    
    void Start()
    {
        text.SetActive(false);

       

        ammoText.text = ammoCount.ToString();

        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Player Movement
        if (!hasDied)
        {
            
            
          
           
           

            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            
            Vector3 moveHorizontal = transform.up * -moveInput.x;

            Vector3 moveVertical = transform.right * moveInput.y;

            rb.velocity = (moveHorizontal + moveVertical) * speed;
             // Checking rigidbody velocity, if it's greater than 1. Animator triggers walking animation
            if (rb.velocity.magnitude >= 1)
            {
                animator.SetTrigger("PlayerMove");
               
                
            }


            

            // Player Mouse view & rotation cannot be more or less the chosen min and max angles in degrees

            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            Vector3 RotAmount = viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);

            viewCam.transform.localRotation = Quaternion.Euler(RotAmount.x, Mathf.Clamp(RotAmount.y, minAngle, maxAngle), RotAmount.z);
            animator.SetTrigger("Idle");
            //Shooting logic

           
            ammoText.text = ammoCount.ToString();
            if (cooldown.IsCoolingDown) return;
            if (Input.GetMouseButtonDown(0))
            {

              

                if (ammoCount == 0)
                {
                    audiosource.PlayOneShot(gunEmpty);
                    
                }
                
                if (ammoCount > 0)
                {
                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;


                    
                    audiosource.PlayOneShot(clip);
                    

                    if (Physics.Raycast(ray, out hit))
                    {
                        
                        Instantiate(bulletImpact, hit.point, viewCam.transform.rotation);
                        cooldown.StartCooldown();
                        if (hit.transform.tag == "Enemy")
                        {
                            
                            hit.transform.parent.GetComponent<EnemyHealth>().TakeDamage();
                            EnemyHealth enemyhealt = GetComponent<EnemyHealth>();
                           

                            

                           
                           
                        }

                       
                    }


                    animator.SetTrigger("Shoot");

                    ammoCount--;

                   

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meds"))
        {




            collision.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {

            StartCoroutine(Dialog());
            text.SetActive(true);
        }

       
    }


    IEnumerator Dialog()
    {
        yield return new WaitForSeconds(10);

        text.SetActive(false);
    }
}
