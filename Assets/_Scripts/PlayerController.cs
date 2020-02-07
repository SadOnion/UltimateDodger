using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion
    private void Awake()
    {
        _instance=this;
    }
    public GameObject[] circles;
    public int projectileLayer=10;
    public VariableJoystick joystick;
    private float speed;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody2D>();
        speed = PlayerStats.Instance.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = joystick.Direction*speed;
    }
    public void Respawn()
    {
        StartCoroutine(RespownCoroutine());
    }

    private IEnumerator RespownCoroutine()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.layer == projectileLayer)
        {
            Die();
            return;
        }
        IPickable pickable = collision.gameObject.GetComponent<IPickable>();
        pickable?.PickUp();
    }

    private void Die()
    {
        Respawn();
    }
}
