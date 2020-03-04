using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500;
    public int health = 5;
    public Text healthText;
    public Text scoreText;
    private int score = 0;
    public Image winLoseBG;


    public Text winLoseText;

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
            SetScoreText();
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            SetWin();
            Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }


    void SetWin()
    {
        winLoseBG.color = Color.green;
        winLoseText.text = "You win!";
        winLoseText.color = Color.black;
        StartCoroutine(LoadScene(3));
    }


    void Update()
		{
			if (health == 0)
			{
				winLoseBG.color = Color.red;
				winLoseText.text = "Game Over!";
				winLoseText.color = Color.white;
            StartCoroutine(LoadScene(3));
			}
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

    }

    private IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        score = 0;
        health = 5;
    }
}