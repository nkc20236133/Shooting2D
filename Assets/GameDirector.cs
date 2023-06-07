using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text KyoriLabel; //距離を表示するUI-Textオブジェクト
    int kyori;

    public Image Timegauge; //タイムゲージを表示するUI

    float lastTime;  //残り時間を保存する変数


    void Start()
    {
        kyori = 0;

        lastTime = 100f; //残り時間１００秒
    }

    void Update()
    {
        
        kyori++;
        KyoriLabel.text = kyori.ToString("D6");

        //残り時間を減らす処理
        lastTime -= Time.deltaTime;
        Timegauge.fillAmount = lastTime / 100f;

        //残り時間が０になったらリロード
        if(lastTime<0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
