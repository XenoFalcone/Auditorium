using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBoxController : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _offColor;
    public Color _onColor;
    public SpriteRenderer[] _bars;
    public float volumePlus = 0.1f;
    public float volumeMinus = 0.1f;
    public float waitInterval = 1f;

    [SerializeField] private float chrono = 0f;
    private bool particleEnter;
    private GameManager gameManager;


    private void Awake()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //On récupère toutes les barres de volume qui composent l'objet
        int i = 0;
        
        foreach (SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
        {
            if (child.tag == "VolumeBar")
            {
                Array.Resize<SpriteRenderer>(ref _bars, _bars.Length + 1);
                _bars[i] = child;
                i++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameManager.victorySwitch == false && gameManager.titleSwitch == false) {
        
        //On parcours les barres de volumes et on regarde si elles sont "activées"
        float i = 1;
        float length = _bars.Length;

        foreach (SpriteRenderer bar in _bars)
        {
            if (_audioSource.volume >= (1f/ length) *i)
            {
                bar.color = _onColor;
            }
            else
            {
                bar.color = _offColor;
            }

            i++;
        }

        //On met un delai avant que le son ne commence à baisser
        if(particleEnter)
        {
            chrono += Time.deltaTime;
            if (chrono > waitInterval) 
            {
                particleEnter = false;
                chrono = 0f;
            }
        }
        else
        {
            //Le volume baisse en permanance après une seconde sans particule
            if (!particleEnter)
            {
                _audioSource.volume -= volumeMinus * Time.deltaTime;
            }
        }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Particule") && gameManager.victorySwitch == false && gameManager.titleSwitch == false)
        {
            particleEnter = true;
            chrono = 0f;

            _audioSource.volume += volumePlus;
        }

    }
}
