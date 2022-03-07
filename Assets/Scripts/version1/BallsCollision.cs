using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public Action OnCollisionBellsPlayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnCollisionBellsPlayer?.Invoke();
        }
    }
}
