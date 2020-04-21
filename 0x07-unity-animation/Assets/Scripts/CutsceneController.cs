using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator ani;
    public GameObject mainCamera;
    public GameObject Player;
    public GameObject TimerCanvas;
    public GameObject CutSCamera;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void transition()
    {
        mainCamera.SetActive(true);
        TimerCanvas.SetActive(true);
        Player.gameObject.GetComponent<PlayerController>().enabled = true;
        CutSCamera.SetActive(false);
    }
}