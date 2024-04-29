using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour
{

    [Header("Game Parameters")]
    
    [Header("Spawn Manager")]
    [SerializeField] private bool activate = true;

    [Tooltip("Time between two spawn")]
    [Range(0f, 20f)]
    [SerializeField] private float spawnInterval = 1f;

    [Tooltip("Chance for a spawn")]
    [Range(0f, 1f)]
    [SerializeField] private float spawnChance = 1;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float spawnRadius = 1f;

    [Header("Change Direction of spawn object")]
    [SerializeField] private bool modifyDirection = false;
    [SerializeField] private Vector3 moveDirection = new Vector3();
    [SerializeField] private float moveSpeed;


    private float chrono = 0f;
    private bool canSpawn = false;
    private Vector2 randomPosition;
    private Vector2 spawnerPosition;


    void Awake()
    {
        //bossPhase = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().BossPhase;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //bossPhase = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().BossPhase;
        spawnerPosition = transform.position;

        if ( activate)
        {

        if (canSpawn)
        {
            //J'essaye de créer un ennemi toutes les X secondes

            float randValue = Random.value;
            if (randValue < spawnChance)
            {
                randomPosition = Random.insideUnitCircle * spawnRadius;
                GameObject particule = Instantiate(Prefab, spawnerPosition + randomPosition, transform.rotation);
                    particule.GetComponent<Movement>().moveDirection = transform.right;
                    if (modifyDirection)
                    {
                        particule.GetComponent<Movement>().moveDirection = moveDirection;
                        particule.GetComponent<Movement>().moveSpeed = moveSpeed;
                    }
                }

            canSpawn = false;

        }

        if (!canSpawn)
        {
            chrono += Time.deltaTime;
        }

        if (chrono >= spawnInterval)
        {
            canSpawn = true;
            chrono = 0f;
        }

        }
    }
}



