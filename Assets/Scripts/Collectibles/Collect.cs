using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collect : MonoBehaviour
{

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Utility.PLAYER_TAG)) {
            if (gameObject.CompareTag(Utility.KEY_TAG)) {
                PlayerPrefs.SetInt(Utility.Collectibles.KEY.ToString(), 1);
            } else if (gameObject.CompareTag(Utility.GOAL_TAG)) {
                PlayerPrefs.SetInt(Utility.Collectibles.GOAL.ToString(), 1);
            }
            PlayerPrefs.Save();
            Destroy(gameObject, .2f);
        }
    }
}
