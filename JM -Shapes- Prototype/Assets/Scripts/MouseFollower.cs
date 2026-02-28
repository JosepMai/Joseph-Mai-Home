using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        // 3. Convert screen coordinates to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // 4. Update the object's position
        transform.position = worldPosition;
    }
}
