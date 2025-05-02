using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public bool isGrounded { get; private set; }
    [SerializeField]
    private float rotationSpeed = 200f;
    [SerializeField]
    private AudioClip jumpAudioClip;
    [SerializeField]
    private ParticleSystem flipParticleSystem;

    private bool isGravityInverted = false;
    private bool hasJumped = false;
    private float groundDistance = 1.1f;
    private Rigidbody playerRigidbody;
    private Quaternion targetRotation;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();

        playerRigidbody.useGravity = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        CheckGround();

        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.G)) {
                hasJumped = true;
                FlipGravity();
                CameraManager.Instance.MoveCameraAfterGravityFlip();
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
        flipParticleSystem.Play();
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
                if (hasJumped) {
                    PlayJumpAudio();
                    hasJumped = false;
                }
            }
        } else {
            isGrounded = false;
        }
    }

    private void PlayJumpAudio() {
        if (audioSource != null) {
            audioSource.PlayOneShot(jumpAudioClip);
        }
    }
}
