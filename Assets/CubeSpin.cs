using UnityEngine;

public class SpinAndShrinkScript : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float shrinkSpeed = 1;

    void Update()
    {
        // Rotate the object around its own axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Shrink the object
            Shrink();
        }
    }

    void Shrink()
    {
        // Calculate the new scale by reducing it based on the shrink speed
        Vector3 newScale = transform.localScale - new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);

        // Clamp the scale to prevent it from going negative
        newScale = new Vector3(Mathf.Max(newScale.x, 0f), Mathf.Max(newScale.y, 0f), Mathf.Max(newScale.z, 0f));

        // Apply the new scale to the object
        transform.localScale = newScale;
    }
}
