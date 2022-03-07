using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private Text textIndex;
    [SerializeField] private TicketIndex ticket;
    [SerializeField] private bool ai,  bonus;
    [SerializeField] private GameObject bonusPrefab;
    
    public void Start()
    {
        textIndex = GetComponentInChildren<Text>();
        if(textIndex)
        {
            index = ticket.Index;
            textIndex.text = index.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bonus)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(gameObject);
                ticket.gameObject.GetComponentInChildren<Text>().color = Color.black;
            }
            if (collision.gameObject.CompareTag("Ball") && ai)
            {
                Destroy(gameObject);
                ticket.gameObject.GetComponentInChildren<Text>().color = Color.red;
            }
        }
        else if(bonus && collision.gameObject.CompareTag("Ball"))
        {
            if (ai)
            {
               var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
                bonus.GetComponent<PowerUp>().SetAiMode(true);
                ticket.gameObject.GetComponentInChildren<Text>().color = Color.red;
                Destroy(gameObject);
            }
            else if(!ai)
            {
                var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
                bonus.GetComponent<PowerUp>().SetAiMode(false);
                ticket.gameObject.GetComponentInChildren<Text>().color = Color.black;
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponentInParent<BrickList>().RemoveBrick();
        }
    }
}
