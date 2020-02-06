using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="MonoSpawnData",fileName ="MonoSpawnData")]
public class MonoSpawnData : ScriptableObject
{
    public Color color;
    public GameObject projectile;
    public float spawnTime;
}
