using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Behaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Transform actualobjetive;

    [SerializeField] float normalvelocity;
    [SerializeField] float runvelocity;
    [SerializeField] float waitingtime;

    [SerializeField]List<GameObject> objetivelist = new();
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patroll();
    }

    public IEnumerator ChangeObjetive(NavMeshAgent agent,List<GameObject> objetives)
    {
        int Num = UnityEngine.Random.Range(0,objetives.Count);

        agent.isStopped = true;

        yield return new WaitForSeconds(waitingtime);

        agent.isStopped = false;

        actualobjetive = objetives[Num].transform;
        agent.SetDestination(objetives[Num].transform.position);
    }

    public void Patroll()
    {
        if (actualobjetive == null)
        {
            StartCoroutine(ChangeObjetive(agent,objetivelist));
            return;
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(ChangeObjetive(agent,objetivelist));
        }
    }
}
