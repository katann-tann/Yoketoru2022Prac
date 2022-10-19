using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("スピード"), SerializeField]
    float speed = 15;

    float cameraDistance;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mpos = Input.mousePosition;
        //Debug.Log(mpos);
        mpos.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mpos);

        //　to = 現在地から目的地wpへの向きと大きさ(ベクトル)
        Vector3 to = wp - transform.position;

       

        // to.magnitude=toの長さ
        if(to.magnitude < 0.01f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            float step = speed * Time.deltaTime;
            float dist = Mathf.Min(to.magnitude, step);
            float v = dist / Time.deltaTime;
            rb.velocity = v * to.normalized;
        }
        //transform.position = wp;
    }
}
