using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public LineRenderer line;
    public float speed;
    private void Start()
    {
        StartCoroutine(ChangeAlpha());
    }

    // Update is called once per frame
    IEnumerator ChangeAlpha()
    {
        yield return new WaitForEndOfFrame();
        line.startColor = new Color(line.startColor.r,line.startColor.g,line.startColor.b,line.startColor.a-Time.deltaTime*speed);
        line.endColor = new Color(line.endColor.r,line.endColor.g,line.endColor.b,line.endColor.a-Time.deltaTime*speed);
        if(line.startColor.a >0)StartCoroutine(ChangeAlpha());
    }
}
