using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake() {
        foreach (var collectible in Enum.GetValues(typeof(Utility.Collectibles))) {
            // safe just because I iterate on collectibles enum and there's no persistence between executions
            PlayerPrefs.DeleteKey(collectible.ToString());
        }
    }

}
