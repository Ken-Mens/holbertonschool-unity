using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



///<summary>Stops a timer</summary>
public class WinTrigger : MonoBehaviour
  {
        public Text timerText;
        public Canvas WinCanvas;
        public AudioSource winsource;
        public AudioSource CheeryMonday;

//    private void Awake()
//    {
//        winsource = GetComponent<AudioSource>();
//        CheeryMonday = GetComponent<AudioSource>();
//    }

    void OnTriggerEnter(Collider change)
        {
        if (change.name == "Player")
        {
            change.gameObject.GetComponent<Timer>().enabled = false;
            timerText.fontSize = 84;
            timerText.color = Color.green;
            winsource.Play();
            CheeryMonday.Stop();
            WinCanvas.gameObject.SetActive(true);
        }
      }
    }
