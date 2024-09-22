using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Info
{
    public int hp;
    public string name;
    
}
public class ProjectSettings : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        SaveInfo();
        Debug.Log("quit");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
     SaveInfo();
     Debug.Log("pause");
    }

    void Awake()
    {
        LoadInfo();
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 1;
        QualitySettings.vSyncCount = 0;
    }

    void LoadInfo()
    {
        PlayerInfo.Instance.Hp = PlayerPrefs.GetFloat("hp") < 0.1 ? 100 : PlayerPrefs.GetFloat("hp");
        PlayerInfo.Instance.Hunger = PlayerPrefs.GetFloat("hunger")< 0.1 ? 100 : PlayerPrefs.GetFloat("hunger");
        PlayerInfo.Instance.Thirst = PlayerPrefs.GetFloat("thirst")< 0.1 ? 100 : PlayerPrefs.GetFloat("thirst");
        var info = JsonConvert.DeserializeObject<Info>(PlayerPrefs.GetString("info"));
    }

    void SaveInfo()
    {
        var info = new Info();
        PlayerPrefs.SetFloat("hp",PlayerInfo.Instance.Hp);
        PlayerPrefs.SetFloat("hunger",PlayerInfo.Instance.Hunger);
        PlayerPrefs.SetFloat("thirst",PlayerInfo.Instance.Thirst);
        PlayerPrefs.SetString("info",JsonConvert.SerializeObject(info));
        
    }
    
}
