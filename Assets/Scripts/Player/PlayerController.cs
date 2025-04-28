using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10;
    private Rigidbody playerRigidbody;
    private Vector3 playerInput;
    private Quaternion targetRotation;
    private float rotationSpeed = 200f;

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

        if (Input.GetKeyDown(KeyCode.G)) {
            FlipGravity();
        }
        
    }

    void FixedUpdate() {
        if (playerRigidbody == null) {
            return;
        }

        MovePlayer();

        FlipPlayer();

    }

    private void FlipGravity() {
        GravityManager.Instance.InvertGravity();
        if (GravityManager.Instance.isGravityReversed) {
            targetRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + 180f);
        } else {
            targetRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z + 180f);
        }
    }

    private void MovePlayer() {
        Vector3 movement = playerInput * playerSpeed;
        playerRigidbody.AddForce(movement);
    }

    private void FlipPlayer() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
