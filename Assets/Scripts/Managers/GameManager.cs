using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
        ResetPlayerCollectibles();
    }

    private void ResetPlayerCollectibles() {
        print("resetting collectibles");
        foreach (var collectible in Enum.GetValues(typeof(Utility.Collectibles))) {
            // safe just because I iterate on collectibles enum and there's no persistence between executions
            PlayerPrefs.DeleteKey(collectible.ToString());
        }
    }

    public void ReloadScene() {
        print("Reload scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
