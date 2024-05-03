using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class SpawnerController : MonoBehaviour
{

    //[SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private float _spawnInterval = 0.1f;
    [SerializeField] private float _moveSpeed = 20f;
    private float _chrono = 0f;

    private ObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        _chrono += Time.deltaTime;

        if (_chrono >= _spawnInterval)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;

            //On récupère la particule
            GameObject particle = pool.ParticuleGet();
            //GameObject particle = Instantiate( _particlePrefab, spawnPosition, Quaternion.identity );

            if (particle == null)
            {
                return;
            }

            //On active la particle
            particle.SetActive(true);

            //On téléporte la particule
            particle.transform.position = spawnPosition;

            //On initialise la particule
            particle.GetComponent<Rigidbody2D>().velocity = transform.right * _moveSpeed;
            _chrono = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _spawnRadius);
        //Gizmos.DrawRay(_mouseRay.origin, _mouseRay.direction * 1000);
    }
}



