using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Timeline.TimelinePlaybackControls;
//using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{


    public float MoveSpeed;
    public string TagToFollow;

    /*[SerializeField][Range(-1f,1f)] private float MoveX;
    [SerializeField][Range(-1f, 1f)] private float MoveY;
    [SerializeField][Range(-1f, 1f)] private float MoveZ;*/

    /*[SerializeField][Range(-1f, 1f)] private float RotateX;
    [SerializeField][Range(-1f, 1f)] private float RotateY;
    [SerializeField][Range(-1f, 1f)] private float RotateZ;*/

    public Vector3 moveDirection = new Vector3();
    public Vector3 rotateDirection = new Vector3();


    private Rigidbody2D _rb2d;
    private Transform _target;
 


    public void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (TagToFollow != "") {
            _target = GameObject.FindGameObjectWithTag(TagToFollow).transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction = new Vector3())
    {
       
        if(_target != null)
        {

            direction = new Vector3(_target.position.x - transform.position.x, _target.position.y - transform.position.y, _target.position.z - transform.position.z);
        }
        else if(moveDirection.x != 0 || moveDirection.y != 0 || moveDirection.z != 0)
        {
            direction = moveDirection;
        }

        _rb2d.velocity = direction.normalized * MoveSpeed;
    }

    public void Rotate(Vector3 direction = new Vector3())
    {

        if (_target != null)
        {
            direction = new Vector3(_target.position.x - transform.position.x, _target.position.y - transform.position.y, _target.position.z - transform.position.z);
        }
        else if(direction.x == 0 && direction.y == 0 && direction.z == 0 )
        {
            if (rotateDirection.x == 0 && rotateDirection.y == 0 && rotateDirection.z == 0)
            {
                direction = moveDirection;
    
            }
            else
            {
                direction = rotateDirection;
            }
        }

        if (direction.x != 0 || direction.y != 0 || direction.z != 0)
        {
 
            Quaternion lookAt = Quaternion.LookRotation(direction, Vector3.back);
            _rb2d.SetRotation(lookAt);
        }
        
    }

}
