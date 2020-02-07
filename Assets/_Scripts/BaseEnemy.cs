using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    protected Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        body=GetComponent<Rigidbody2D>();
        StartCoroutine(StartMovingTowardsPlayer());
    }

    protected virtual IEnumerator StartMovingTowardsPlayer()
    {
        yield return new WaitForSeconds(1);
        body.velocity = GetDirection()*speed;
    }
    protected Vector2 GetDirection()
    {
        GameObject[] obj = PlayerController.Instance.circles;
        float dist0 = Vector2.Distance(body.position,obj[0].transform.position);
        float dist1 = Vector2.Distance(body.position,obj[1].transform.position);
        
        Vector2 playerPos = dist0>dist1?obj[1].transform.position:obj[0].transform.position;
        Vector2 dir = playerPos-body.position;
        dir.Normalize();
        return dir;
    }
   
}
