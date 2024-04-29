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
    public float volumeModifier = 0.1f;

    [SerializeField] private float chrono = 0f;
    private bool particleEnter;


    private void Awake()
    {
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

        if(particleEnter)
        {
            chrono += Time.deltaTime;
            if (chrono > 1f) 
            {
                particleEnter = false;
                chrono = 0f;
            }
        }
        else
        {
            //Le volume baisse en permanance
            if (!particleEnter)
            {
                _audioSource.volume -= volumeModifier * Time.deltaTime;
            }
        }

        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        particleEnter = true;
        chrono = 0;
        _audioSource.volume += volumeModifier;
    }
}
