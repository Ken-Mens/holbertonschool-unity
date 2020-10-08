using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class VRcontroller : MonoBehaviour
{
    public float m_sensitivity = 0.1f;
    public float max_speed = 1.0f;

    public SteamVR_Action_Boolean m_movepres = null;
    public SteamVR_Action_Vector2 m_movevalue = null;

    private float m_speed = 0.0f;


    private CharacterController m_controlla = null;
    private Transform m_camerarig = null;
    private Transform m_head = null;


    private void Awake()
    {
        m_controlla = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_camerarig = SteamVR_Render.Top().origin;
        m_head = SteamVR_Render.Top().head;    
    }

    private void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMove();
       
    }

    private void HandleHead()
    {
        //store current 
        Vector3 Oldposition = m_camerarig.position;
        Quaternion Oldrotation = m_camerarig.rotation;
        // rotation
        transform.eulerAngles = new Vector3(0.0f, m_head.rotation.eulerAngles.y, 0.0f);

        // Restore
        m_camerarig.position = Oldposition;
        m_camerarig.rotation = Oldrotation;


    }

    private void CalculateMove()
    {
        // movement orientation

        Vector3 orientationeuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationeuler);
        Vector3 movement = Vector3.zero;

        // If not moving

        if (m_movepres.GetStateUp(SteamVR_Input_Sources.Any))
            m_speed = 0;

        // If button pressed
        if (m_movepres.state)
        {
            // add, clamp
            m_speed += m_movevalue.axis.y * m_sensitivity;
            m_speed = Mathf.Clamp(m_speed, -max_speed, max_speed);

            movement += orientation * (m_speed * Vector3.forward) * Time.deltaTime;
        
        }

        // Apply

        m_controlla.Move(movement);

    }

    private void HandleHeight()
    {
        // Get the head local space
        float headHeight = Mathf.Clamp(m_head.localPosition.y, 1, 2);
        m_controlla.height = headHeight;

        // Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_controlla.height / 2;
        newCenter.y += m_controlla.skinWidth;

        //move capsule in local space
        newCenter.x = m_head.localPosition.x;
        newCenter.z = m_head.localPosition.z;

        //Rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        // Apply
        m_controlla.center = newCenter;
    }
}
