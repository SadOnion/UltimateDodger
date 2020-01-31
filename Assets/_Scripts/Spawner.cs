using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]CircleSpawner spawner =null;
    [SerializeField]BombSpawner bombSpawner=null;
    public GameObject[] circleEnemies;
    public Coin coin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnBombs());
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnBombs()
    {
        yield return new WaitForSeconds(5);
        bombSpawner.SpawnBomb();
        StartCoroutine(SpawnBombs());

    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        spawner.SpawnOnRandomPosition(circleEnemies[UnityEngine.Random.Range(0,circleEnemies.Length)]);
        StartCoroutine(Spawn());

    }
    IEnumerator SpawnCoin()
    {
        float rand= UnityEngine.Random.Range(10,15);
        yield return new WaitForSeconds(rand);
        float x =UnityEngine.Random.Range(-7.5f,7.5f);
        float y =UnityEngine.Random.Range(-4f,4f);
        Vector2 randomPos = new Vector2(x,y);
        Instantiate(coin,randomPos,coin.transform.rotation);
        StartCoroutine(SpawnCoin());
    }
}
