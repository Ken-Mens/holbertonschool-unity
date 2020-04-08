using UnityEngine;

    ///<summary>Handles camera control</summary>
    public class CameraController : MonoBehaviour
    {

        public float turn = 3f;
        public Transform player;
        private Transform t;
        public bool isInverted;
        private Vector3 offset;
        private Quaternion turnX;
        private Quaternion turnY;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            isInverted = false;
        else
            isInverted = true;
        t = GetComponent<Transform>();
    }
     
    void Start()
        {
            Cursor.visible = false;
            offset = new Vector3(0, 1.25f, -6.25f);
        }

    void Update()
    {
        turnX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn, Vector3.up);
        if (isInverted == true)
        {
            turnY = Quaternion.AngleAxis(-1 * (Input.GetAxis("Mouse Y") * turn), Vector3.left);
        }
        else
        {
            turnY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turn, Vector3.left);
        }
        offset = turnX * turnY * offset;
        transform.position = player.position + offset * Time.timeScale;
        transform.LookAt(player.transform.position);
    }
}