using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickList : MonoBehaviour
{
    [SerializeField] private List<Brick> bricks;

    public void RemoveBrick()
    {
        for (int i = 0; i < bricks.Count; i++)
        {
            if (!bricks[i])
            {
                bricks.RemoveAt(i);
            }
        }
        StartCoroutine(CorTryRemoveBrick());

        IEnumerator CorTryRemoveBrick()
        {
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < bricks.Count; i++)
            {
                if (!bricks[i])
                {
                    bricks.RemoveAt(i);
                }
            }
            if (bricks.Count == 0)
            {
                print("ïÎÁÅÄÈË ÊÀÊÎÉ ÒÎ ÈÃÐÎÊ");
            }
        }
    }
}
