using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public static class Data{
    public static bool[] Charactor_state = new bool[4];
}
public class GameManager : MonoBehaviour {
    Text ResultText;
    bool IsPause;
	void Start () {
        ResultText = GameObject.Find("ResultText").GetComponent<Text>();
        ResultText.text = "";
        IsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPause)
            {
                IsPause = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (IsPause)
            {
                IsPause = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        int State_No = 0;
        for(int i = 0;i < 4; i++)
        {
            if (Data.Charactor_state[i]) State_No++;
        }
        if (State_No == 4) ResultText.text = "Victory";
    }
}
