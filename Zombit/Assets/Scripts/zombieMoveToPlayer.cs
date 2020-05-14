using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMoveToPlayer : MonoBehaviour
{
    private Transform target;
    private float speed = 3f;
    private Animator anim;
    public PlayerHP player;

    public float attackRate = 1f;
    float nextattack = 0f;
    private float temp;
    private bool turn = true;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        //attack if close to player
        if (Time.time >= nextattack)
        {
            if (Vector3.Distance(target.position, transform.position) <= 2)
            {
                anim.SetBool("attack", true);
                player.TakeDamage(10);
                nextattack = Time.time + 1f / attackRate;
                StartCoroutine(stopattack());
            }

        }
        temp = target.position.x - transform.position.x;
        if (temp > 0 && turn) flip();
        else if (temp < 0 && !turn) flip();
    }

    IEnumerator stopattack()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("attack", false);
    }

    void flip()
    {
        turn = !turn;
        transform.Rotate(Vector3.up * 180);
    }
}
