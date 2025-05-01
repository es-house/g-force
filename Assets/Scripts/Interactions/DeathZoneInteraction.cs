using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeathZoneInteraction : MonoBehaviour {
    [SerializeField]
    private AudioClip youLoseAudioClip;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Utility.PLAYER_TAG)) {
            StartCoroutine(ResetAndReload());
        }
    }

    IEnumerator ResetAndReload() {
        PlayYouLoseAudio();
        yield return new WaitForSeconds(youLoseAudioClip.length);
        GameManager.Instance.ReloadScene();
    }

    private void PlayYouLoseAudio() {
        if (audioSource != null) {
            audioSource.PlayOneShot(youLoseAudioClip);
        }
    }
}
