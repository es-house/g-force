using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField]
    private GameObject victoryImage;
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

    public void ShowVictoryScreen() {
        StartCoroutine(Victory());
    }

    IEnumerator Victory() {
        print("call show page");
        yield return new WaitForSeconds(.3f);
        victoryImage.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitApplication() {
        # if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        # else
            Application.Quit();
        # endif
    }

    public void ResetTimeScale() {
        Time.timeScale = 1;
    }

    public void ResetAndReload() {
        ResetTimeScale();
        ReloadScene();
    }

}
