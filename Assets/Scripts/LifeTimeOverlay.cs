using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeOverlay : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifetime;

    void Start()
    {
        
    }

    // Destroys the bullet
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
