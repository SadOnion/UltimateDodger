using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tripler : BaseEnemy
{
    public UnityEvent OnSplit;
    public GameObject triplet;
    public float splitAngle;
    private GameObject[] players;
    protected override void Start()
    {
        base.Start();
        players = PlayerController.Instance.circles;
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position,players[0].transform.position) <= 5 || Vector2.Distance(transform.position,players[1].transform.position) <= 5)
        {
            Split();
        }
    }
    public void Split()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        float rot = Vector2.Angle(body.velocity,Vector2.right);
        if(body.velocity.y<0)rot*=-1; 
        Rigidbody2D[] bodies = Instantiate(triplet,body.position,Quaternion.Euler(0,0,rot)).GetComponentsInChildren<Rigidbody2D>();
        float x = body.velocity.x;
        float y=body.velocity.y;
        float angle=15*Mathf.Deg2Rad;

        bodies[0].velocity = new Vector2(x*Mathf.Cos(angle)-y*Mathf.Sin(angle),x*Mathf.Sin(angle)+y*Mathf.Cos(angle)).normalized*speed;
        bodies[1].velocity = body.velocity;
        bodies[2].velocity = new Vector2(x*Mathf.Cos(-angle)-y*Mathf.Sin(-angle),x*Mathf.Sin(-angle)+y*Mathf.Cos(-angle)).normalized*speed;


        
        OnSplit?.Invoke();

    }
   

}
