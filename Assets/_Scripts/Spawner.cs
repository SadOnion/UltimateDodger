using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]CircleSpawner spawner =null;
    [SerializeField]BombSpawner bombSpawner=null;
    public GameObject[] circleEnemies;
    public MonoSpawnData[] monoSpawnDatas;
    public Coin coin;
    public Walls walls;
    Coroutine spawnMethod;

    // Start is called before the first frame update
    void Start()
    {
        spawnMethod = StartCoroutine(SpawnRandomAll());
        StartCoroutine(SpawnCoin());
        StartCoroutine(NextMethod());
    }
    
    private IEnumerator NextMethod()
    {
        float rand = UnityEngine.Random.Range(8,10);
        yield return new WaitForSeconds(rand);
        StopCoroutine(spawnMethod);
        yield return new WaitForSeconds(3);
        IEnumerator newMethod = ChooseNewMethod();
        spawnMethod = StartCoroutine(newMethod);
        StartCoroutine(NextMethod());
    }

    private IEnumerator ChooseNewMethod()
    {
        int rand = UnityEngine.Random.Range(0,3);
         walls.ChangeColor(monoSpawnDatas[rand].color);
        return Spawn(rand);
    }

    private IEnumerator SpawnBombs()
    {
        yield return new WaitForSeconds(5);
        bombSpawner.SpawnBomb();
        StartCoroutine(SpawnBombs());

    }
     IEnumerator Spawn(int index)
    {
        yield return new WaitForSeconds(monoSpawnDatas[index].spawnTime);
        spawner.SpawnOnRandomPosition(monoSpawnDatas[index].projectile);
        StartCoroutine(Spawn(index));

    }
    IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(1);
        spawner.SpawnOnRandomPosition(circleEnemies[UnityEngine.Random.Range(0,circleEnemies.Length)]);
        StartCoroutine(SpawnRandom());

    }
    IEnumerator SpawnRandomAll()
    {
        for (int i = 0; i < 5; i++)
        {
        yield return new WaitForSeconds(1);
        spawner.SpawnOnRandomPosition(circleEnemies[UnityEngine.Random.Range(0,circleEnemies.Length)]);
        }
        bombSpawner.SpawnBomb(); 
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
