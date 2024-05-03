using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVolume(float value)
    {

        float decibel = Mathf.Log10(value) * 20f;
        mixer.SetFloat("MusicVolume", decibel);
    }
}
