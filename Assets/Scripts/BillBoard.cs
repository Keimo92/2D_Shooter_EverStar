using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour

{

    private BoxCollider2D boxcollider;
    private SpriteRenderer Sr;

    // Get the spriterendere preference and flips the sprite
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();

        Sr.flipX = true;
        
    }

    // Objects are looking at the players position OldSchool way
    void Update()
    {

        transform.LookAt(PlayerMovement.instance.transform.position, -Vector3.forward);

       

    }




}