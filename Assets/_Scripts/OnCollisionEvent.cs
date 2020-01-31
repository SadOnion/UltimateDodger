using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke();
    }
}
