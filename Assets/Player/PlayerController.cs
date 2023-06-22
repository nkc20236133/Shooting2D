using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; //移動方向を保存する変数
    float speed;    // 移動速度保存
    float timer;    // 自弾の発射間隔計算用
    Animator anim;

    public GameObject shotPre; // 弾のプレハブをセット

    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 1, 20);
        }
        get { return speed; }
    }

    int shotLevel;  // 武器のレベル
    public int ShotLevel
    {
        set
        {
            shotLevel = value;
            shotLevel = Mathf.Clamp(shotLevel, 0, 12);
        }
        get { return shotLevel; }
    }

    void Start()
    {
        //アニメーターコンポネントの情報を保存
        anim=GetComponent<Animator>();
        shotLevel = 0;  // 弾レベル
        timer = 0;  // 時間初期化
        speed = 10; // 初期スピード
    }

    void Update()
    {
        float speed = 10;

        //移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized* speed * Time.deltaTime;

        // CキーでshotLevel変更(デバッグ用)
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotLevel = (shotLevel + 1) % 13;
        }

        // Zキーが押されているとき弾を発射
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;
            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // 弾の生成位置はプレーヤーと同じ場所
                Vector3 p = transform.position;

                // プレーヤーの回転角度を取得し、15度ずつずらした方向に弾を回転させる
                //Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                //Quaternion rot = Quaternion.Euler(r);
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // 位置と回転情報をセットして生成
                Instantiate(shotPre, p, rot);
            }
        }

        //アニメーション設定
        if (dir.y==0)
        {
            //アニメーションクリップ[Player]を再生
            anim.Play("Player");
        }
        else if(dir.y==1)
        {
            anim.Play("PlayerL");
        }
        else if(dir.y==-1)
        {
            anim.Play("PlayerR");
        }

        //画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // アニメーション設定
        if (dir.y == 0) anim.Play("neutral");
        else if (dir.y == 1) anim.Play("LMove");
        else if (dir.y == -1) anim.Play("RMove");
    }
}
