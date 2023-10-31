using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f;
    public float shootRange = 3.0f;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootCooldown = 1.0f;

    

   

    public Animator animator;

    private int damage = 20;

    public AudioSource audiosource;

    public AudioClip clip;
   
    public Rigidbody2D rb;
        
    private float nextShootTime;

    private GameObject wall;


    private void Start()
    {

        rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is within the detection radius
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
          
        if (distanceToPlayer <= detectionRadius)
        {
            animator.SetTrigger("enemyWalk");
            // Rotate towards the player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

           
           

            // Move towards the player
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Check if it's time to shoot

      


            if (distanceToPlayer <= shootRange && Time.time >= nextShootTime)
            {
                Shoot();
                nextShootTime = Time.time + shootCooldown;
            }
            
        
            
        }
        if(distanceToPlayer > detectionRadius)
        {
            animator.SetTrigger("enemyIdle");
        }
    }

    public void Shoot()
    {
        // Work in Progress, Make enemy movement stop when shooting!!
        animator.SetTrigger("enemyShoot");


        // Instantiate a bullet and set its direction
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 20f; // Adjust the speed as needed
        Destroy(bullet, 2f); // Destroy the bullet after 2 seconds (adjust as needed)

        audiosource.PlayOneShot(clip);

    }



   public void TakeDamage()
    {
        EnemyHealth.instance.health -= damage;

      

        
        
    }






}
