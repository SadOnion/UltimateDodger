using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public SpriteRenderer[] renderers;

    public void ChangeColor(Color color)
    {
        foreach (var item in renderers)
        {
            item.color = color;
        }
    }
}
