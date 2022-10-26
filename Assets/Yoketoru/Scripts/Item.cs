using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    static int count;

    public Item(): base()
    {
        count++;
        //Debug.Log(count);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Item);
            GameManager.AddPoint(point);
            Destroy(gameObject);

            count--;
            if (count <=0)
            {
                GameManager.ToClear();
            }
        }
    }


    public static void ClearCount()
    {
        count = 0;
    }
}
