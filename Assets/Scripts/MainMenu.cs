using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    static private bool cb_Mode;

    // Use this for initialization
    void Start () {
        colorblindMode.isOn = cb_Mode;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayMaze()
    {
        cb_Mode = colorblindMode.isOn;
        if (cb_Mode)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }

        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
