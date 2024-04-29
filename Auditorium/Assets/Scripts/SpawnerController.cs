using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float time;
    public GameObject[] enemies;
    public bool spawned = false;
}

public class SpawnerController : MonoBehaviour
{

    [Header("Game Parameters")]

    [Header("Shot Manager")]
    [Tooltip("Time between two spawn")]
    [Range(1f, 20f)]
    public float spawnInterval;
    [Tooltip("Chance for an ennemy to spawn")]
    [Range(0f, 1f)]
    public float spawnChance;
    public GameObject EnemyPrefab;

    [Tooltip("Wave Mode")]
    //public EnemyWave[] waves;

    private float chrono = 0f;
    private bool canSpawn = false;
    private bool bossPhase = false;


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

        if ( !bossPhase)
        {

        if (canSpawn)
        {
            //J'essaye de créer un ennemi toutes les X secondes

            float randValue = Random.value;
            if (randValue < spawnChance)
            {
                Instantiate(EnemyPrefab, transform.position, transform.rotation);
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
        //WaveMode activated
        else
        {

        }
    }
}



