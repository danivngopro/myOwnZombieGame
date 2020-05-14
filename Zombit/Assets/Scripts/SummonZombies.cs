using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SummonZombies : MonoBehaviour
{
    private GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.Find("Zombie");
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
            yield return new WaitForSeconds(0.46f);
            getZombie();
        }
    }

    void getZombie()
    {
        Vector3 position = new Vector3(Random.Range(-75f, 75f), Random.Range(-75f, 75f), 0);
        zombie.GetComponent<SpriteRenderer>().enabled = true;
        Instantiate(zombie, position, Quaternion.identity);
        zombie.GetComponent<SpriteRenderer>().enabled = false;
    }
}
