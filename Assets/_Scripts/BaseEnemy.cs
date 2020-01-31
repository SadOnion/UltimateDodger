using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    protected Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
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
        Vector2 playerPos = PlayerController.Instance.transform.position;
        Vector2 dir = playerPos-body.position;
        dir.Normalize();
        return dir;
    }
   
}
