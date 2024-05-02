using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static SceneFader;

public class ParticleController : MonoBehaviour
{

    public TrailRenderer _tr;
    private Rigidbody2D _rb2d;

    private void OnEnable()
    {
        StartCoroutine(WaitForTrailRenderer());
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb2d.velocity.magnitude <= 0.1f)
        {
            _rb2d.velocity = Vector2.zero;
            _tr.emitting = false;
            _tr.Clear();
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        
    }

    public IEnumerator WaitForTrailRenderer()
    {

        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds(1f);
        _tr.emitting = true;
    }

}
