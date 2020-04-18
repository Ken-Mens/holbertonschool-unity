using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator animat;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public GameObject cutCamera;

    void Awake()
    {
        animat = GetComponent<Animator>();
    }

    public void transition()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        //cutCamera.gameObject.GetComponent<CutsceneController>().enabled = false;
        cutCamera.SetActive(false);
    }
}