using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
    {
        public Text timerText;
        private float startTime;
    public GameObject ok;
    public Canvas winCanvas;
    private string text;
    public Text TextWin;

    // Use this for initialization
    void Start()
        {
            startTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }

    public void Win()
    {
        ok.gameObject.GetComponent<CameraController>().enabled = false;
        TextWin.text = timerText.text;
        timerText.enabled = false;
        
    }
}