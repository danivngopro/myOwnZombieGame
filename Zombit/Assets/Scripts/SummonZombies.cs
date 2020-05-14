using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SummonZombies : MonoBehaviour
{
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonZ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SummonZ()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            getZombie();
        }
    }

    void getZombie()
    {
        Vector3 position = new Vector3(Random.Range(-75f, 75f), Random.Range(-75f, 75f), 0);
        Instantiate(zombie, position, Quaternion.identity);
    }
}
