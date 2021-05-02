using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoor : MonoBehaviour
{
    public GameObject perkMenu;
    public GameObject doorOn;
    public GameObject doorOff;
    public GameObject player;

    public bool isParent; // To allow the script to be used with parent and children.
                          // Not sure if this is saving code or making it needlessly
                          // complicated.

    private FirstPersonLook playerMouse;
    private FirstPersonMove playerWasd;
    private GameObject[] enemies;
    private bool menuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMouse = player.GetComponent<FirstPersonLook>();
        playerWasd = player.GetComponent<FirstPersonMove>();

        if (isParent)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy"); // List of enemies
            doorOn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isParent)
        {
            if (enemies.Length == 0 || enemies == null) // Waits for enemy count to hit 0
            {
                doorOn.SetActive(true);
            }

            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isParent && !menuOpen)
        {
            perkMenu.SetActive(true);
            playerMouse.isPlaying = false;  // Kills player movement while menu open
            playerWasd.canMove = false;
            menuOpen = true;
        }
    }
}
