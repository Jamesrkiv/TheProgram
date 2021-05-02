using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Animator anim;

    public float speed = 10;
    

    //Sight
    public float heightMultiplier;
    public float sightDist = 10;

    public GameObject targetPlayer;

    public enum Status
    {
        INVESTIGATE,
        ATTACK
    }

    public Status status;

    public int attackDistance = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        heightMultiplier = 1.36f;
        status = Enemy.Status.INVESTIGATE;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(enemyActions());
    }

    
    IEnumerator enemyActions()
    {
        switch(status)
        {
            case Status.INVESTIGATE:
                investigate();
                break;

            case Status.ATTACK:
                attack();
                break;
        }
        yield return null;
    }

    void investigate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);

        if(Physics.Raycast (transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                targetPlayer = hit.collider.gameObject;
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                targetPlayer = hit.collider.gameObject;
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                targetPlayer = hit.collider.gameObject;
                Debug.Log("Detected");
            }
        }
    }

    void attack()
    {
        transform.LookAt(targetPlayer.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
        anim.SetBool("See player", true);
        if (Vector3.Distance(transform.position, targetPlayer.transform.position) < attackDistance)
        {
            anim.SetBool("In range", true);
        }
        else
        {
            anim.SetBool("In range", false);
        }
    }
}
