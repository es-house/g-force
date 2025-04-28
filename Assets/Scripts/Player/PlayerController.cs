using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10;
    private Rigidbody playerRigidbody;
    private Vector3 playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (playerRigidbody == null) {
            return;
        }

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        
    }

    void FixedUpdate() {
        if (playerRigidbody == null) {
            return;
        }

        Vector3 movement = playerInput * playerSpeed;
        playerRigidbody.AddForce(movement);
    }
}
