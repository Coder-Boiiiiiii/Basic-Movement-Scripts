using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller2 : MonoBehaviour
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
        Z_input = Input.GetAxis("Vertical");
    }

    //Movement Func
    private void Move()
    {
        rb.AddForce(new Vector3(X_input, 0f, Z_input) * PlayerSpeed);
    }

    //Collision Detection
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(Next_lvl_Index);
        }

    }
}
