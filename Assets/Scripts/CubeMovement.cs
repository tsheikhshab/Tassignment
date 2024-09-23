using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public GameObject spherePrefab;  // Reference to the sphere prefab
    public float dropRate = 0.5f;    // Time between sphere drops
    private float timeSinceLastDrop = 0f; // Time tracker
    public float sphereLifetime = 5f; // Time in seconds before the spheres disappear

    void Update()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 for movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the cube
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Update the timer for sphere drops
        timeSinceLastDrop += Time.deltaTime;

        // Check if enough time has passed to drop a new sphere
        if (movement.magnitude > 0 && timeSinceLastDrop >= dropRate)
        {
            // Reset the timer
            timeSinceLastDrop = 0f;

            // Instantiate a small sphere at the cube's current position
            GameObject newSphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);

            // Change the sphere's color to a random color
            Renderer sphereRenderer = newSphere.GetComponent<Renderer>();
            if (sphereRenderer != null)
            {
                sphereRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }

            // Destroy the sphere after 5 seconds
            Destroy(newSphere, sphereLifetime);
        }
    }
}
