using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGameFunc);
        }
    }
    void StartGameFunc()
    {
        SceneManager.LoadScene(1);
    }
    
}
