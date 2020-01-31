using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVelocity : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D body;
    public float speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = velocity*speed;
    }

    
}
