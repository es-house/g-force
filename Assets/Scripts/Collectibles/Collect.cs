using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collect : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Utility.PLAYER_TAG)) {
            if (gameObject.CompareTag(Utility.KEY_TAG)) {
                PlayerPrefs.SetInt(Utility.Collectibles.KEY.ToString(), 1);
            } else if (gameObject.CompareTag(Utility.GOAL_TAG)) {
                PlayerPrefs.SetInt(Utility.Collectibles.GOAL.ToString(), 1);
            }
            if (audioClip != null) {
                Play2DAudio(audioClip);
            }
            PlayerPrefs.Save();
            Destroy(gameObject, .2f);
        }
    }

    private void Play2DAudio(AudioClip audioClipToPlay) {
        GameObject audio = new GameObject("Audio");
        AudioSource audioSource = audio.AddComponent<AudioSource>();
        audioSource.clip = audioClipToPlay;
        audioSource.spatialBlend = 0f;
        audioSource.volume = .6f;
        audioSource.Play();

        Destroy(audio, audioClipToPlay.length);
    }
}
