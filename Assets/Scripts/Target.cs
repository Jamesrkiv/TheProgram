
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    public int health = 100;
    public Slider slider;
    private void Awake()
    {
        slider.maxValue = 100;
    }
    void Update()
    {
        setHealth(health);
    }
    public void setHealth(int health)
    {

        slider.value = health;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
