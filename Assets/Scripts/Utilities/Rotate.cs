using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 70f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
}
