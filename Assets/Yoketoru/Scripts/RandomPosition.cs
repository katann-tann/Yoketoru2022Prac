using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    [SerializeField]
    Bounds spawnBounds;

    // Start is called before the first frame update
    void Awake()
    {
        var pos = transform.position;
        pos.x = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        pos.y = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnBounds.center, spawnBounds.size);
    }
}
