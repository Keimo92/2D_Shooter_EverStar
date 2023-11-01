using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public static EnemyHealth instance;

    public Animator animator;

    public ParticleSystem particle;

    public int health = 40;

    public int damage = 20;

    public AudioSource audiosource;

    public AudioClip clip;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 40;
    }

    // Update is called once per frame
    void Update()
    {       
        // Checking health if it's 0 get Ai script disable it, set animation trigger to dead animation
        if(health == 0)
        {
            EnemyAI enemyai = GetComponent<EnemyAI>();

            enemyai.enabled = false;

            enemyDead();

            particle.Emit(1);

            
           
            
            Destroy(gameObject, 1);
           
        }
    }
   

    public void enemyDead()
    {
        animator.SetTrigger("enemyDead");
        audiosource.PlayOneShot(clip);
        
    }



   public void TakeDamage()
    {
        health -= damage;
        EnemyAI enemyai = GetComponent<EnemyAI>();

        enemyai.detectionRadius = 100;
        enemyai.shootRange = 10;

       

        
    }

}

    

        



