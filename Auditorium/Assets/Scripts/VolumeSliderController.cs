using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }
}
