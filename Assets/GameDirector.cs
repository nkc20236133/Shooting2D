using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text KyoriLabel; //������\������UI-Text�I�u�W�F�N�g
    int kyori;

    public Image Timegauge; //�^�C���Q�[�W��\������UI

    float lastTime;  //�c�莞�Ԃ�ۑ�����ϐ�


    void Start()
    {
        kyori = 0;

        lastTime = 100f; //�c�莞�ԂP�O�O�b
    }

    void Update()
    {
        
        kyori++;
        KyoriLabel.text = kyori.ToString("D6");

        //�c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        Timegauge.fillAmount = lastTime / 100f;

        //�c�莞�Ԃ��O�ɂȂ����烊���[�h
        if(lastTime<0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
