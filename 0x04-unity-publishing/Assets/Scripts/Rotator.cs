
using UnityEngine;

///<summary>Rotates GameObjects.</summary>
public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(45 * Time.deltaTime, 0, 0, Space.Self);
    }
}
