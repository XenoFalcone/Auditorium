using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMagnitudeController : MonoBehaviour
{
    public float magnitudeRatio = 3f;
    public float magnitudeMin = 10f;

    private PointEffector2D _objectEffector;
    private CircleShape _circleShape;

    // Start is called before the first frame update
    void Start()
    {
        _objectEffector = GetComponent<PointEffector2D>();
        _circleShape = GetComponent<CircleShape>();
    }

    // Update is called once per frame
    void Update()
    {
        _objectEffector.forceMagnitude = Mathf.Clamp(-_circleShape.Radius * magnitudeRatio, magnitudeMin, _circleShape.Radius * magnitudeRatio);
    }
}
