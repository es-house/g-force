using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200f;

    private bool isGravityInverted = false;
    private Rigidbody playerRigidbody;
    private Quaternion targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();

        playerRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            FlipGravity();
        }
    }

    void FixedUpdate() {
        ApplyGravity();
        FlipPlayer();
    }

    private void ApplyGravity() {
        Vector3 gravityDirection = Vector3.down;
        if (isGravityInverted) {
            gravityDirection = Vector3.up;
        }
        playerRigidbody.AddForce(gravityDirection * Utility.GRAVITY, ForceMode.Acceleration);
    }

    private void FlipGravity() {
        isGravityInverted = !isGravityInverted;

        targetRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + Utility.PLAYER_ROTATION);
    }

    private void FlipPlayer() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
