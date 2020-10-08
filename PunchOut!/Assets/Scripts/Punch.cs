using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Punch : MonoBehaviour
{
    public SteamVR_TrackedObject hand;
    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.MovePosition(hand.transform.position);
        rbody.MoveRotation(hand.transform.rotation);

    }
}
