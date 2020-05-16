using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private bool isRunning;
    private Animator anim;
    private bool turn = true;
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;

    //movement impare
    private bool canMoveRight = true, canMoveLeft = true, canMoveUp = true, canMoveDown = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckCollision();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && canMoveUp && canMoveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            isRunning = true;
            if (!turn) flip();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && canMoveUp && canMoveLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
            isRunning = true;
            if (turn) flip();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && canMoveDown && canMoveLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            isRunning = true;
            if (turn) flip();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && canMoveDown && canMoveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            isRunning = true;
            if (!turn) flip();
        }
        else if (Input.GetKey(KeyCode.W) && canMoveUp)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            isRunning = true;
        }
        else if (Input.GetKey(KeyCode.S) && canMoveDown)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            isRunning = true;
        }
        else if (Input.GetKey(KeyCode.A) && canMoveLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            isRunning = true;
            if (turn) flip();
        }
        else if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            isRunning = true;
            if (!turn) flip();
        }
        else isRunning = false;

        if(isRunning == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void flip()
    {
        turn = !turn;
        transform.Rotate(Vector3.up * 180);
    }

    void CheckCollision()
    {
        RaycastHit2D hitinfoRight = Physics2D.Raycast(firepoint1.position, firepoint3.position, 7f);
        RaycastHit2D hitinfoLeft = Physics2D.Raycast(firepoint2.position, firepoint4.position , 8f);
        RaycastHit2D hitinfoDown = Physics2D.Raycast(firepoint2.position, firepoint1.position, 4f);
        RaycastHit2D hitinfoUp = Physics2D.Raycast(firepoint4.position, firepoint3.position, 4.2f);

        if (hitinfoRight != false)
        {
            if (hitinfoRight.transform.tag == "stop")
            {
                Debug.Log("can't move right");
                canMoveRight = false;
            }
            else canMoveRight = true;
        }
        else if (hitinfoLeft != false)
        {
            if (hitinfoLeft.transform.tag == "stop")
            {
                Debug.Log("can't move left");
                canMoveLeft = false;
            }
            else canMoveLeft = true;
        }
        if (hitinfoDown != false)
        {
            if (hitinfoDown.transform.tag == "stop")
            {
                Debug.Log("can't move down");
                canMoveDown = false;
            }
            else canMoveDown = true;
        }
        else if (hitinfoUp != false)
        {
            if (hitinfoUp.transform.tag == "stop")
            {
                Debug.Log("can't move up");
                canMoveUp = false;
            }
            else canMoveUp = true;
        }

    }
}