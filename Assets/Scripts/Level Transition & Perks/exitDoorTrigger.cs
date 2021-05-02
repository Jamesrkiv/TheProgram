using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitDoorTrigger : MonoBehaviour
{
    public GameObject perkMenu;
    public GameObject pTracker;

    public Button b1;
    public Button b2;
    public Button b3;

    public Text bTxt1;
    public Text bTxt2;
    public Text bTxt3;

    public GameObject player;

    private string[] possPerks = new string[7];

    private FirstPersonLook playerMouse;
    private FirstPersonMove playerWasd;
    private bool menuOpen = false;
    private bool perkPicked = false;
    private perkTracker perks;

    // Start is called before the first frame update
    void Start()
    {
        perks = pTracker.GetComponent<perkTracker>();

        // Perk list
        possPerks[0] = "+10 HP";
        possPerks[1] = "+20 Max HP";
        possPerks[2] = "- Gravity";
        possPerks[3] = "+ Gravity";
        possPerks[4] = "+ Dash Speed";
        possPerks[5] = "+ Dash Distance";
        possPerks[6] = "+ Speed";

        // Accesses text on buttons before activating perks menu
        bTxt1.text = possPerks[Random.Range(0, possPerks.Length)];
        bTxt2.text = possPerks[Random.Range(0, possPerks.Length)];
        bTxt3.text = possPerks[Random.Range(0, possPerks.Length)];

        // Listener functions for buttons
        b1.onClick.AddListener(b1Func);
        b2.onClick.AddListener(b2Func);
        b3.onClick.AddListener(b3Func);

        playerMouse = player.GetComponent<FirstPersonLook>();
        playerWasd = player.GetComponent<FirstPersonMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !menuOpen)
        {
            pTracker.GetComponent<perkTracker>().startingHP = player.GetComponent<PlayerHealth>().currentHealth;

            perkMenu.SetActive(true);
            playerMouse.isPlaying = false;  // Kills player movement while menu open
            playerWasd.canMove = false;
            menuOpen = true;
        }
    }

    void b1Func()
    {
        disableButtons();
        if (!perkPicked)
        {
            perkPicked = true;
            sendToTracker(bTxt1.text);
        }
    }

    void b2Func()
    {
        disableButtons();
        if (!perkPicked)
        {
            perkPicked = true;
            sendToTracker(bTxt2.text);
        }
    }

    void b3Func()
    {
        disableButtons();
        if (!perkPicked)
        {
            perkPicked = true;
            sendToTracker(bTxt3.text);
        }
    }

    void disableButtons()
    {
        b1.enabled = false;
        b2.enabled = false;
        b3.enabled = false;
    }

    // Applies powerup from chosen button
    void sendToTracker(string powerupChose)
    {
        switch (powerupChose)
        {
            case "+10 HP":
                perks.startingHP += 10;
                break;
            case "+20 Max HP":
                perks.hpBonus += 20;
                break;
            case "- Gravity":
                perks.gravReduct -= 1;
                break;
            case "+ Gravity":
                perks.gravReduct += 1;
                break;
            case "+ Dash Speed":
                perks.dashBonus += 1;
                break;
            case "+ Dash Distance":
                perks.dashDist += 0.1f;
                break;
            case "+ Speed":
                perks.speedBonus += 1;
                break;
            default:
                Debug.Log("Error with perks");
                break;
        }
    }
}
