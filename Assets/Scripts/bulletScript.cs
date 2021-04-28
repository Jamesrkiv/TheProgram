using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletSpeed;
    public int bulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        Target target = other.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
