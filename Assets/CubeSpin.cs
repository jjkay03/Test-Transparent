using UnityEngine;

public class SpinScript : MonoBehaviour
{
    // Adjust the speed of rotation as needed
    public float rotationSpeed = 30f;

    void Update()
    {
        // Rotate the object around its own axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
