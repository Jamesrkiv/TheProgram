using UnityEngine.UI;
using UnityEngine;

public class projectileGunScript : MonoBehaviour
{
    public GameObject projectilePrefab; //Bullet prefab
    public GameObject gunBarrel; //Gun barrel Position
    public int maxAmmo;
    public int ammo;
    public Text ammoCount;

    public bool debugLaser = false;

    public float speed = 20;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (debugLaser) Aim(); //Laser for Debuging Aim from gunBarrel Position

        ammoCount.text = ammo.ToString() + "/" + maxAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo > 0))
        { 
            ammo--;
            fireWeapon();
        }
    }

    void fireWeapon()
    {
        GameObject bullet = Instantiate(projectilePrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime);
    }

    //Debug Laser -- Click Gizmo to See in game in editer or to remove.
    void Aim()
    {
        Vector3 screenCenter = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(gunBarrel.transform.position, screenCenter, Color.green);
    }
}

