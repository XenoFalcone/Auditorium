using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] musicBox;
    private bool victory;
    private float chrono = 0f;
    [SerializeField] private float timeForVictory = 2f;

    public UnityEvent victoryEvent;
    public UnityEvent startEvent;

    // Start is called before the first frame update
    void Start()
    {
        musicBox = GameObject.FindGameObjectsWithTag("MusicBox");
        startEvent.Invoke();

    }

    // Update is called once per frame
    void Update()
    {

        victory = true;

        foreach (var item in musicBox)
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
                victoryEvent.Invoke();
                Debug.Log("Victory !!!!");
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
}
