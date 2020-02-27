using UnityEngine;
using UnityEngine.SceneManagement;


///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500;
    public int health = 5;
    private int score = 0;



    private void Start()
    {
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
        void Update()
        {
            if (health == 0)
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene("Maze", LoadSceneMode.Single);
                score = 0;
                health = 5;
            }
        }
    }