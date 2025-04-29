using System.Collections;
using UnityEngine;

public class DeathZoneInteraction : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Utility.PLAYER_TAG)) {
            StartCoroutine(ResetAndReload());
        }
    }

    IEnumerator ResetAndReload() {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.ReloadScene();
    }
}
