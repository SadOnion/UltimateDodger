using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public float radius=1f;
    
    public void SpawnOnRandomPosition(GameObject obj)
    {
        Instantiate(obj,RandomCirclePosition(),obj.transform.rotation);
    }
    private Vector3 RandomCirclePosition()
    {
        float angle = Random.Range(0,361)*Mathf.Deg2Rad;
        Vector3 vec = transform.position+ new Vector3(Mathf.Cos(angle)*radius,Mathf.Sin(angle)*radius,0);
        return vec;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
