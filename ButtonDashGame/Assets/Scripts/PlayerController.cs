using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 10f;
    public float accelerationPerTap = 1f;
    public float deceleration = 1f;
    public Animator animator;
    public bool isRunning = false;
    public float timer = 10f; 
    public float tapCooldown = 0.1f;
    private float lastTapTime = 0f;
    public Transform finishLine;

    private bool gameOver = false;

    private void Start()
    {
        FinishLineController.OnPlayerWin += OnFinish;
    }
    void Update()
    {
        if (!gameOver)
        {
            HandleInput();
            UpdateTimer();
        }
    }

    void OnFinish()
    {


    }

    void HandleInput()
    {
        
        if (Input.GetMouseButtonDown(0)) // Of voor toetsenbord: Input.GetKeyDown(KeyCode.Space)
        {
            if (Time.time - lastTapTime > tapCooldown) 
            {
                isRunning = true;
                speed += accelerationPerTap;
                speed = Mathf.Clamp(speed, 0, maxSpeed); 
                lastTapTime = Time.time;
            }
        }

     
        if (Time.time - lastTapTime > tapCooldown && !Input.GetMouseButton(0))
        {
            speed -= deceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed); 
            isRunning = speed > 0; 
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
            Debug.Log("Finish bereikt!");   
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
