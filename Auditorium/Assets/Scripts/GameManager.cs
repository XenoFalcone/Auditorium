using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _musicBoxes;
    private bool victory;
    private float chrono = 0f;
    [SerializeField] private float timeForVictory = 2f;

    public UnityEvent victoryEvent;
    public UnityEvent startEvent;
    public UnityEvent titleEvent;
    public bool victorySwitch = false;
    public bool titleSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        var i = 0;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("MusicBox");

        _musicBoxes = new AudioSource[boxes.Length];

        foreach (var musicObject in boxes)
        {
                _musicBoxes[i] = musicObject.GetComponent<AudioSource>();
                i++;
        }

        startEvent.Invoke();

    }

    // Update is called once per frame
    void Update()
    {

        victory = true;

        foreach (var item in _musicBoxes)
        {
            if(item.GetComponent<AudioSource>().volume != 1f)
            {
                victory = false;
                break;
            }
        }

        if (victory)
        {
            chrono += Time.deltaTime;

            if (chrono > timeForVictory)
            {
                victorySwitch = true;
                victoryEvent.Invoke();
                //Debug.Log("Victory !!!!");
            }

        }
        else
        {
            chrono = 0f;
        }
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void GoToTitle()
    {
        titleSwitch = true;
        titleEvent.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
