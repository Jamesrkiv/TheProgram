using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] projectiles;
    public int ammoCount;
    public int maxAmmo;
    public Text ammo;

    private GameObject randomGun;

    public Animator ammoBlink;

    private void Awake()
    {
        RandomStartGun();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = ammoCount.ToString() + "/" + maxAmmo.ToString();
        if (ammoCount <= 0)
        {
            Destroy(randomGun);
            StartCoroutine(RandomGunSelect());
            ammoCount = 1;

        }
    }

    void RandomStartGun()
    {
        randomGun = Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, transform.rotation);
        randomGun.transform.parent = gameObject.transform;
    }

    IEnumerator RandomGunSelect()
    {
            yield return new WaitForSeconds(Random.Range(.5f, 2.5f));
            randomGun = Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, transform.rotation);
            randomGun.transform.parent = gameObject.transform;
            ammoCount += Random.Range(10, maxAmmo);
            ammoBlink.SetBool("new weapon", true);
            yield return new WaitForSeconds(.5f);
            ammoBlink.SetBool("new weapon", false);
    }
}
