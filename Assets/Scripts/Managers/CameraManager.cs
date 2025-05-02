using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private CinemachineFollow cinemachineFollow;
    [SerializeField]
    private float duration = 1f;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }
    
    public void MoveCameraAfterGravityFlip() {
        float y = -cinemachineFollow.FollowOffset.y;
        Vector3 targetPosition = new Vector3(cinemachineFollow.FollowOffset.x, y, cinemachineFollow.FollowOffset.z);
        StartCoroutine(MoveCamera(cinemachineFollow, targetPosition, duration));
    }

    IEnumerator MoveCamera(CinemachineFollow cinemachine, Vector3 targetPosition, float time) {
        float elapsed = 0;
        while (elapsed < time) {
            cinemachine.FollowOffset = Vector3.Lerp(cinemachine.FollowOffset, targetPosition, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cinemachine.FollowOffset = targetPosition;
    }
}
