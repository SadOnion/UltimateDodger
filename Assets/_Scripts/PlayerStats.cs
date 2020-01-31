using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    private static PlayerStats _instance;
    public static PlayerStats Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject o = new GameObject("PlayerStats");
                _instance = o.AddComponent<PlayerStats>();
            }
            return _instance;
        }
    }
#endregion
    public int Coins{ get;private set;}
    public int Speed{ get;private set;}
    [SerializeField]CoinPanel coinPanel=null;
    private void Awake()
    {
        _instance=this;
    }
    private void Start()
    {
        Coins = 0;
        Speed = 5;
    }
    public void AddCoins(int amount)
    {
        Coins+=amount;
        coinPanel.anim.SetTrigger("CoinPicked");
    }
    public bool TakeCoins(int amount)
    {
        if(Coins - amount >= 0)
        {
            Coins-=amount;
            return true;
        }
        else
        {
            return false;
        }
    }

}
