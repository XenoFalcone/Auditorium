using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;

public class TitleManager : MonoBehaviour
{

    public UnityEvent startEvent;
    public UnityEvent startGameEvent;

    // Start is called before the first frame update
    void Start()
    {
        startEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        startGameEvent.Invoke();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
