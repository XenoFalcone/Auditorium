using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    private Ray _mouseRay;
    private RaycastHit2D _intersection;
    [SerializeField] private Texture2D _mouseMove;
    [SerializeField] private Texture2D _mouseResize;
    [SerializeField] private GameManager gameManager;

    [Header("Radius parameters")]
    public float minRadius = 1.0f;
    public float maxRadius = 10.0f;
    public float magnitudeRatio = 3f;
    public float magnitudeMin = 10f;

    private bool _isClicked = false;
    private GameObject _objectToMove;
    private CircleShape _objectToResize;
    private AreaEffector2D _objectEffector;

    private Vector2 _mousePositionWorld;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(_objectToResize +" Resize");
        //Debug.Log(_objectToMove + "Move");
        if (gameManager.victorySwitch == false && gameManager.titleSwitch == false)
        {

            if (_isClicked && _objectToMove != null)
            {
                //Debug.Log("Move");
                _objectToMove.transform.position = new Vector2(_mousePositionWorld.x, _mousePositionWorld.y);

            }
            else if (_isClicked && _objectToResize != null)
            {
                float radius = Vector2.Distance(_objectToResize.transform.position, _mousePositionWorld);
                _objectToResize.Radius = Mathf.Clamp(radius, minRadius, maxRadius);
                _objectEffector.forceMagnitude = Mathf.Clamp(_objectToResize.Radius * magnitudeRatio, magnitudeMin, _objectToResize.Radius * magnitudeRatio);
                //magnitudeMin - magnitudeRatio + _objectToResize.Radius * magnitudeRatio;
            }
            /*else if (!_isClicked)
            {
                _objectToMove = null;
                _objectToResize = null;
            }*/
        }
    }

    public void PointerPosition(InputAction.CallbackContext context)
    {
        
        
        Vector2 mousePosition = context.ReadValue<Vector2>();
        //Debug.Log(mousePosition);
        //Debug.Log(Camera.main);

        if (mousePosition == null || Camera.main == null)
        {
            return;
        }

        _mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        //Debug.Log(mousePosition);
        _intersection = Physics2D.GetRayIntersection(_mouseRay);

        _mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        //if (!_isClicked || (_objectToMove == null && _objectToResize == null))
        if (!_isClicked)
        {

            if (_intersection.collider != null && gameManager.victorySwitch == false && gameManager.titleSwitch == false)
            {
                if (_intersection.collider.CompareTag("Effector"))
                {
                    Cursor.SetCursor(_mouseResize, new Vector2(256f, 256f), CursorMode.Auto);
                    _objectToMove = null;
                    _objectToResize = _intersection.collider.gameObject.GetComponent<CircleShape>();
                    _objectEffector = _intersection.collider.gameObject.GetComponent<AreaEffector2D>();

                }
                else if (_intersection.collider.CompareTag("Arrow"))
                {
                    Cursor.SetCursor(_mouseMove, new Vector2(256f, 256f), CursorMode.Auto);
                    _objectToMove = _intersection.collider.transform.parent.gameObject;
                    _objectToResize = null;

                };
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                _objectToMove = null;
                _objectToResize = null;
            }
        }

    }

    public void Click(InputAction.CallbackContext context)
    {

        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                //Debug.Log("Shoot commencé!");
                break;
            case InputActionPhase.Performed:
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                _isClicked = false;
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        /*Gizmos.color = Color.green;
        Gizmos.DrawRay(_mouseRay.origin, _mouseRay.direction * 1000);*/
    }
}
