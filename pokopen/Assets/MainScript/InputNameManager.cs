using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputNameManager : MonoBehaviour
{
    InputField Nameinput;
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        Nameinput = GameObject.Find("InputField").GetComponent<InputField>();
    }
    
    void Update()
    {
        
    }

    public void InputButtom()
    {
        if (Data.CharactorName == null)
        {
            Data.CharactorName = Nameinput.text;
            Nameinput.text = null;
        }
        SceneManager.LoadScene("TestOnline");
    }
}
