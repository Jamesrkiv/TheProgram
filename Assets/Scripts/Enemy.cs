using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Investigate
    private Vector3 investigateSpot;
    private float timer = 0;
    public float investigateWait = 10;

    //Sight
    public float heightMultiplier;
    public float sightDist = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        heightMultiplier = 1.36f;
    }

    // Update is called once per frame
    void Update()
    {
        investigate();
    }

    void investigate()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);

        if(Physics.Raycast (transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                //state = enemy.State.CHASE;
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                //state = enemy.State.CHASE;
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                //state = enemy.State.CHASE;
                Debug.Log("Detected");
            }
        }
    }
}
