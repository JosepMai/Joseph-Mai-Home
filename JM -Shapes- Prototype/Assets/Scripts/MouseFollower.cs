using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        // 2. Adjust the Z position (distance from the camera)
        // This is crucial for 3D or if you are using an orthographic camera in a specific setup.
        // A common value for 2D is 10 units away from the camera for default settings.
        mousePosition.z = 10f;

        // 3. Convert screen coordinates to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 4. Update the object's position
        transform.position = worldPosition;
    }
}
