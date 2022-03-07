using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField] private GameObject spawnerBall;
    [SerializeField] private GameObject ball;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(ball, spawnerBall.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
    public void InstanceBall()
    {
       var b = Instantiate(ball, spawnerBall.transform.position, Quaternion.identity);
    }
}
