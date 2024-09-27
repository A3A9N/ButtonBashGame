using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 10f;
    public float acceleration = 0.5f;
    public float deceleration = 1f;
    public Animator animator;
    public bool isRunning = false;
    public float timer = 10f; 

    private bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            HandleInput();
            UpdateTimer();
        }
    }

    void HandleInput()
    {
        
        if (Input.GetKey(KeyCode.Space)) // Of voor toetsenbord: Input.GetKey(KeyCode.Space)
        {
            isRunning = true;
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        else
        {
            isRunning = false;
            speed -= deceleration * Time.deltaTime;
            if (speed < 0)
            {
                speed = 0;
            }
        }

       
        animator.SetBool("isRunning", isRunning);

       
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void UpdateTimer()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameOver(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameOver(true); 
        }
    }

    void GameOver(bool didWin)
    {
        gameOver = true;
        speed = 0;
        if (didWin)
        {
            animator.SetTrigger("win");
        }
        else
        {
            animator.SetTrigger("lose");
        }
    }
}

