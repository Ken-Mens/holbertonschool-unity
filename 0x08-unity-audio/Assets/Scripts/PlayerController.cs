using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController controlla;
    private Transform pp;
    public Transform cam_r; 
    private Vector3 mving = Vector3.zero;
    private Vector3 facing = Vector3.zero;
    private Quaternion Rot;
    private float limbo;
    public float speed = 10f;
    public float jump = 10f;
    
    public Canvas pause_c;
    private Transform ty;
    private Animator anim;
    private float falling = 0f;

    
    void Awake() 
    {
        controlla = GetComponent<CharacterController>();
        pp = GetComponent<Transform>();
        ty = pp.Find("ty");
        anim = ty.GetComponent<Animator>();
    }

    void Update()
    {
        limbo = mving.y;
        mving = Vector3.zero;
        if (Input.GetKey("w"))
            mving = Vector3.forward + mving;
        if (Input.GetKey("s"))
            mving = Vector3.back + mving;
        if (Input.GetKey("d"))
            mving = Vector3.right + mving;
        if (Input.GetKey("a"))
            mving = Vector3.left + mving;
        mving = ((cam_r.right * mving.x) + (cam_r.forward * mving.z)) * speed;
        if (controlla.isGrounded)
        {
            Jump();
        }
        else
        {
            falling += Time.deltaTime;
            anim.SetBool("Grounded", false);
        }
        if (mving != Vector3.zero)
        {
            facing = new Vector3(mving.x, 0, mving.z);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        mving.y = limbo;
        mving.y = mving.y - (25 * Time.deltaTime);
        controlla.Move(new Vector3(mving.x, mving.y, mving.z) * Time.deltaTime);
        if (mving != Vector3.zero)
        {
            Rot = Quaternion.LookRotation(facing);
            ty.rotation = Rot;
        }
        anim.SetFloat("Fall", falling);
        if (pp.position.y < -50.0f)
            pp.position = new Vector3(0, 10, 0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_c.GetComponent<PauseMenu>().Pause();
        }
         
        void Jump()
        {
            falling = 0;
            anim.SetBool("Grounded", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                limbo = jump;
                anim.SetTrigger("Jump");
            }
            else
                limbo = 0;
        }
    }
}
