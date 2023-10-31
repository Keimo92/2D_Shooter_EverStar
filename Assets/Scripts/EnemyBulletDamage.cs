using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{

    public int damage = 20;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth.instance.playerHealth -= damage;
           
            Destroy(gameObject);
        }
    }
}
