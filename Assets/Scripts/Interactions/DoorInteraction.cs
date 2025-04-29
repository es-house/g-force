using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorInteraction : MonoBehaviour
{
    private bool isOpen = false;
    private bool canRotate = false;
    private float rotationSpeed = 10f;
    private float degreeCheck = 0.5f;
    private float degreeRotation = 90f;
    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        if (canRotate) {
            OpenDoor();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Utility.PLAYER_TAG) && !isOpen && !canRotate) {
            bool hasKey = PlayerPrefs.GetInt(Utility.Collectibles.KEY.ToString()) == 1 ? true : false;
            if (hasKey) {
                targetRotation = Quaternion.Euler(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y - degreeRotation,
                    transform.eulerAngles.z
                );
                canRotate = true;
            } else {
                print("player doesn't have the key");
            }
        }
    }

    private void OpenDoor() {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        if (Quaternion.Angle(transform.rotation, targetRotation) <= degreeCheck) {
            transform.rotation = targetRotation;
            canRotate = false;
            isOpen = true;
        }
    }
}
