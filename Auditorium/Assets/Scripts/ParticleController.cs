using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ParticleController : MonoBehaviour
{

    //public UnityEvent OnUpdate;
    private Rigidbody2D _rb2d;


    public void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb2d.velocity.x == 0 && _rb2d.velocity.y == 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeDirection()
    {
        GetComponent<Movement>().Move(transform.up);
    }
}
