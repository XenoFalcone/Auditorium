using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using static SceneFader;

public class SceneFader : MonoBehaviour
{

    #region FIELDS
    public RawImage fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    //public string nextScene;

    private GameObject[] musicBox;

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    #endregion

    #region MONOBHEAVIOR
    /*void OnEnable()
    {
        StartCoroutine(Fade(FadeDirection.Out));
    }*/
    public void FadeOut()
    {
        StartCoroutine(Fade(FadeDirection.Out));
    }

    public void FadeOutMusic()
    {
        musicBox = GameObject.FindGameObjectsWithTag("MusicBox");
        foreach (GameObject music in musicBox)
        {
            StartCoroutine(FadeMusic(music.GetComponent<AudioSource>()));
        }
        
    }

    public void FadeIn(string scene)
    {
        StartCoroutine(FadeAndLoadScene(FadeDirection.In, scene));
    }
    #endregion

    #region FADE
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion

    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }

    private IEnumerator FadeMusic(AudioSource music)
    {

        var timeElapsed = 0f;
        var maxVolume = music.volume;

        while (music.volume > 0)
        {
            music.volume = Mathf.Lerp(maxVolume, 0f, timeElapsed / fadeSpeed);
            timeElapsed += Time.deltaTime;
            yield return 0.1f;
        }
    }
    #endregion
}
