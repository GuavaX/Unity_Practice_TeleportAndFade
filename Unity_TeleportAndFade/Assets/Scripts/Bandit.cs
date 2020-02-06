using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bandit : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent nav;
    private Animator ani;
    private AudioSource aud;
    public AudioClip[] sound;

    private float stopDistance = 2;

    private void Start()
    {
        target = GameObject.Find("玩家").GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        int i = Random.Range(0, 1);
        //aud.PlayOneShot(sound[0]);

        nav.stoppingDistance = stopDistance;

        //ani.SetBool("Walk", true);        
        ani.SetBool("Run", true);        
    }

    private void Update()
    {
        nav.SetDestination(target.position);
        transform.LookAt(target.position);

        if (nav.remainingDistance < stopDistance)
        {
            //ani.SetBool("Walk", false);
            ani.SetBool("Run", false);
            ani.SetTrigger("kick");
        }
        else
        {
            //ani.SetBool("Walk", true);
            ani.SetBool("Run", true);
        }
    }


}
