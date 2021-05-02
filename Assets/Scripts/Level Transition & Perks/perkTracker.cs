using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// IMPORTANT:
// Because we reload the player object for every scene,
// the object attached to this script will not be reloaded
// and will be used to update the player's stats according
// to their accumulated perks at the beginning of each level.

public class perkTracker : MonoBehaviour
{
    public float hpBonus = 0f;      // Additional HP
    public float speedBonus = 0f;   // Additional speed
    public float dashBonus = 0f;    // Dash speed bonus
    public float dashDist = 0f;     // Dash distance bonus
    public float gravReduct = 0f;   // Gravity reduction(/addition)

    public GameObject perkTrackerObj;

    private string refSceneName;    // For tracking the current scene
    private string sceneName;       // against the recorded name

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(perkTrackerObj);
        refSceneName = SceneManager.GetActiveScene().name;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (!sceneName.Equals(refSceneName)) // New scene loaded
        {
            Debug.Log("New scene detected!");
            refSceneName = SceneManager.GetActiveScene().name;
            applyPerks();
        }
    }

    // Applies bonus attributes to player
    void applyPerks()
    {

    }
}
