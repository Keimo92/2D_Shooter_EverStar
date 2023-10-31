using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamage : MonoBehaviour
{
    public static PlayerBulletDamage instance;

    public int damage = 20;




    void Awake()
    {
        instance = this;
    }


    

}