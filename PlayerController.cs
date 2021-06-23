using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //Vars
    public Rigidbody rb;
    public float PlayerSpeed = 15f;
    public float Slowness_Speed;
    public int Next_lvl_Index;

    private float X_input;
    private float Z_input;

    //Awake function
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Inputs    
    void Update()
    {
        Inputs();
    }

    //Movement
    private void FixedUpdate()
    {
        Move();
    }

    //Input check
    private void Inputs()
    {
        X_input = Input.GetAxis("Horizontal");
    }

    //Movement Func
    private void Move()
    {
        rb.AddForce(new Vector3(X_input* PlayerSpeed, 0f, 10f));
    }

    //Collision Detection
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (col.gameObject.tag == "Slowness")
        {
            StartCoroutine("Slowness");
        }

        else if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(Next_lvl_Index);
        }

    }

    //Slowess Coroutine
    IEnumerator Slowness() 
    {
        PlayerSpeed = Slowness_Speed;
        yield return new WaitForSeconds(10f);
        PlayerSpeed = 15f;
    }
}
