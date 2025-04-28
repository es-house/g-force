using UnityEngine;

public class GravityManager : MonoBehaviour
{

    public bool isGravityReversed = false;
    public static GravityManager Instance;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvertGravity() {
        if (isGravityReversed) {
            Physics.gravity = new Vector3(0f, -Utility.GRAVITY, 0f);
        } else {
            Physics.gravity = new Vector3(0f, Utility.GRAVITY, 0f);
        }
        isGravityReversed = !isGravityReversed;
    }
}
