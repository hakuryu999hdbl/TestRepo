﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Trigger : MonoBehaviour
{
    public void ButtonVoice() 
    {
        AudioManager_2.SoundPlay(1);//手动SE音频替换
    }
    public void ClickVoice()
    {
        AudioManager_2.SoundPlay(4);//手动SE音频替换
    }
    public void SetActiveFalse() 
    {
        gameObject.SetActive(false);
    }

    [Header("便捷切换")]
    public List<GameObject> List; // 使用List来存储多个音乐

    bool isOn = false;

    public void SwitchOnOff() 
    {
        isOn = !isOn;

        // 在这里添加更多逻辑来处理音乐的开/关
        if (isOn)
        {
            List[0].gameObject.SetActive(true);
        }
        else
        {
            List[0].gameObject.SetActive(false);
        }

    }//便捷切换
}
