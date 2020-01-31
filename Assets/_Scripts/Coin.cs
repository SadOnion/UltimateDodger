using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour,IPickable
{
    public UnityEvent OnPickUp;
    public int value;
    public Animator anim;
    public float timeActive=5f;
    public void PickUp()
    {
        PlayerStats.Instance.AddCoins(value);
        OnPickUp?.Invoke();
    }
    private void Start()
    {
        Invoke("TimeOut",timeActive);
    }
    public void TimeOut()
    {
        anim.SetTrigger("TimeOut");
    }

}
