using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200f;

    private bool isGravityInverted = false;
    private bool isGrounded = false;
    private float groundDistance = 1.1f;
    private Rigidbody playerRigidbody;
    private Quaternion targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();

        playerRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        CheckGround();

        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.G)) {
                FlipGravity();
            }
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

    private void CheckGround() {
        Vector3 directionGroundCheck = Vector3.down;
        if (isGravityInverted) {
            directionGroundCheck = Vector3.up;
        }

        if (Physics.Raycast(transform.position, directionGroundCheck, out RaycastHit hit, groundDistance)) {
            if (hit.collider.CompareTag("Ground")) {
                isGrounded = true;
            }
        } else {
            isGrounded = false;
        }
    }
}
