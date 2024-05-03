using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public int qtyToCreate;
    public GameObject prefabToCreate;
    //private static GameObject[] pool;
    public GameObject[] pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new GameObject[qtyToCreate];

        for (int i = 0; i < qtyToCreate; i++)
        {
            pool[i] = Instantiate(prefabToCreate, transform);
            pool[i].SetActive(false);
        }
    }

    /*public static GameObject Get()
    {
        foreach (GameObject item in pool)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }

        return null;
    }*/

    public GameObject ParticuleGet()
    {
        foreach (GameObject item in pool)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
}
