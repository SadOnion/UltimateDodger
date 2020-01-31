using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{   
    [SerializeField]Rigidbody2D body=null;
    [SerializeField]Animator anim=null;
    [SerializeField]GameObject explosion=null;
    public UnityEvent OnDetonate;
    public void StartMoving(Vector2 vel)
    {
        body.velocity= vel;
        Invoke("Grow",2f);
    }
    public void Grow()
    {
        anim.SetTrigger("Grow");
    }
    public void Detonate()
    {
        OnDetonate?.Invoke();
    }
    public void SpawnExplosives()
    {
        Instantiate(explosion,transform.position,explosion.transform.rotation);
    }
}
