using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3. zero; //移動方向
    float speed = 5;　　　　　　//移動速度

    void Start()
    {
        //寿命4秒
        Destroy(gameObject,4f);
    }

    void Update()
    {
        //移動方向を決定
        dir = Vector3.left;

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy OnTriggerEnter2D");
    }
}
