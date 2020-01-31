using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    private float xMin=-8,xMax=8;
    private float yMin=-4,yMax=4;
    [SerializeField]GameObject bomb=null;
    public float speed;

    public void SpawnBomb()
    {
        int rand = UnityEngine.Random.Range(0,4);
        Direction dir = (Direction)rand;
        Vector2 pos = RandomLinePosition(dir);
        GameObject o = Instantiate(bomb,pos,bomb.transform.rotation);
        o.GetComponent<Bomb>().StartMoving(Velocity(dir));
    }

    private Vector2 RandomLinePosition(Direction dir)
    {
         Vector2 velocity=Vector2.zero;
        switch (dir)
        {
            case Direction.Down:
                velocity = new Vector2(UnityEngine.Random.Range(xMin,xMax),yMin);
                break;
             case Direction.Up:
                velocity = new Vector2(UnityEngine.Random.Range(xMin,xMax),yMax);
                break;
             case Direction.Right:
                velocity = new Vector2(xMax, UnityEngine.Random.Range(yMin,yMax));
                break;
             case Direction.Left:
                velocity = new Vector2(xMin, UnityEngine.Random.Range(yMin,yMax));
                break;


        }
        return velocity;
    }
     private Vector2 Velocity(Direction dir)
    {
        Vector2 spawnPoint=Vector2.zero;
        switch (dir)
        {
            case Direction.Down:
                spawnPoint = Vector2.up*speed;
                break;
             case Direction.Up:
               spawnPoint = Vector2.down*speed;
                break;
             case Direction.Right:
                spawnPoint = Vector2.left*speed;
                break;
             case Direction.Left:
                spawnPoint = Vector2.right*speed;
                break;


        }
        return spawnPoint;
    }
    
    private enum Direction
    {
        Up,Down,Left,Right
    }
}

