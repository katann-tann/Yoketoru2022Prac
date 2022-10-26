using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Item);
            GameManager.AddPoint(point);
            Destroy(gameObject);
        }
    }
}
