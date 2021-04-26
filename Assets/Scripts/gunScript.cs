
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public Camera fpsCam;


    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzle.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 1f);
        }
    }
}
