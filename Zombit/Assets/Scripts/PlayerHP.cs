using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int health;
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(kill());
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        print(health);
    }

    IEnumerator kill()
    {
        anim.SetTrigger("death");

        yield return new WaitForSeconds(0.48f);

        Destroy(gameObject);
    }
}
