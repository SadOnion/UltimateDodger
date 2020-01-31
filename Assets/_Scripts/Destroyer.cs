using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyAfter=0f;
    // Start is called before the first frame update
    void Start()
    {
        if(destroyAfter > 0)Destroy(gameObject,destroyAfter);
    }

    public void DestroyNow()
    {
        Destroy(gameObject);
    }
}
