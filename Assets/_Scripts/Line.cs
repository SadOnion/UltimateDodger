using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pos>=10) Destroy(this);
        pos+=Time.deltaTime;
        lineRenderer.SetPosition(1,new Vector3(pos,0,0));
    }
}
