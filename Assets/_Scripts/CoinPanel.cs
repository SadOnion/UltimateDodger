using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinPanel : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animator anim;
    public void UpdateText()
    {
        text.text= PlayerStats.Instance.Coins.ToString();
    }
}
