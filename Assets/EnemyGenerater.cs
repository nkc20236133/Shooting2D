using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre;  // 敵のプレハブを保存する変数
    float span = 1f;
    float delta = 0;

    void Start()
    {

    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // 敵を生成する
            this.delta = 0;
            GameObject go =Instantiate(enemyPre);
            int px = Random.Range(4, -5);
            go.transform.position = new Vector3(10, px, 1);
        }

    }
}