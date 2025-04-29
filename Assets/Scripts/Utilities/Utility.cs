using UnityEngine;

public class Utility
{

    public static readonly float GRAVITY = 9.81f;
    public static readonly float PLAYER_ROTATION = 180f;
    public static readonly string PLAYER_TAG = "Player";
    public static readonly string KEY_TAG = "Key";
    public static readonly string GOAL_TAG = "Goal";

    public enum Collectibles {
        KEY,
        GOAL
    }
    
}
