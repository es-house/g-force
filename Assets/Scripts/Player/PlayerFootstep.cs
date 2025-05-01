using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootstep : MonoBehaviour
{
    [SerializeField]
    private AudioClip walkAudioClip;
    [SerializeField]
    private AudioClip runAudioClip;

    private AudioSource audioSource;
    private Rigidbody playerRigidbody;
    private PlayerGravity playerGravity;

    private float walkStepRate = 0.5f;
    private float runStepRate = 0.3f;
    private float stepTimer;
    private float moveThreshold = 0.1f;
    private float runThreshold = 5f;
    private bool isRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody>();
        stepTimer = walkStepRate;
        playerGravity = GetComponent<PlayerGravity>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalVelocity = playerRigidbody.linearVelocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.magnitude > moveThreshold && playerGravity.isGrounded) {
            stepTimer -= Time.deltaTime;
            if (horizontalVelocity.magnitude > runThreshold) {
                isRunning = true;
            } else {
                isRunning = false;
            }
            float currentStepRate = isRunning ? runStepRate : walkStepRate;
            if (stepTimer <= 0f) {
                PlayFootstep(isRunning);
                stepTimer = currentStepRate;
            }
        } else {
            stepTimer = walkStepRate;
        }
    }

    private void PlayFootstep(bool running) {
        AudioClip audioClip = running ? runAudioClip : walkAudioClip;
        if (audioSource != null) {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
