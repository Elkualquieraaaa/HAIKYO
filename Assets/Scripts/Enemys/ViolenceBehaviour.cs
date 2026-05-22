using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ViolenceBehaviour : MonoBehaviour
{
    Transform actualobjetive;
    GlobalTime globalTime;
    float actualTime;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] float initialvelocity;
    [SerializeField] float maxvelocity;
    [SerializeField] float waitingtime;
    [SerializeField] float Maxseconds;
    [SerializeField] float SpawnCouldown;

    [SerializeField] List<GameObject> objetivelist = new();

    void Start()
    {
        globalTime = GameManager.instance.globaltime;
        actualTime = globalTime.Actualtime;
        Disappear();
    }

    void LateUpdate()
    {
        if (globalTime.Actualtime > actualTime + SpawnCouldown)
        {
            TrySpawn();
        }

        if (actualobjetive != null)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                agent.isStopped = true;
                actualobjetive = null;
                Disappear();
            }
        }
    }

    public IEnumerator ChangeObjetive(int num)
    {
        int Num = UnityEngine.Random.Range(0, objetivelist.Count);

        while (num == Num)
        {
            Num = UnityEngine.Random.Range(0, objetivelist.Count);
        }

        agent.isStopped = true;

        yield return new WaitForSeconds(waitingtime);

        agent.isStopped = false;

        actualobjetive = objetivelist[Num].transform;
        agent.SetDestination(objetivelist[Num].transform.position);
    }

    public void Patroll(int num)
    {
        if (actualobjetive == null)
        {
            StartCoroutine(ChangeObjetive(num));
            return;
        }
    }

    public void Disappear()
    {
        agent.ResetPath();
        actualTime = globalTime.Actualtime;
        agent.gameObject.SetActive(false);
        Debug.Log("Violence has disappear");
    }

    public void TrySpawn()
    {
        float probability = (globalTime.Actualtime / Maxseconds) * 100;

        float luck = UnityEngine.Random.Range(0,100);

        float speedpercentage = (globalTime.Actualtime / Maxseconds) * maxvelocity;

        if (luck <= probability)
        {
            Appear(speedpercentage);
        }
        else
        {
            actualTime = globalTime.Actualtime;
        }

        Debug.Log(probability+" y te toco "+luck);
    }

    public void Appear(float velocity)
    {
        if (agent.gameObject.activeSelf == false)
        {
            int Num = UnityEngine.Random.Range(0, objetivelist.Count);

            agent.transform.position = objetivelist[Num].transform.position;

            agent.gameObject.SetActive(true);

            agent.Warp(objetivelist[Num].transform.position);

            if (velocity <= initialvelocity)
            {
                agent.speed = initialvelocity;
            }
            if (velocity >= maxvelocity)
            {
                agent.speed = maxvelocity;
            }
            else
            {
                agent.speed = velocity;
            }

            Patroll(Num);

            Debug.Log("Violence has appear");
        }
    }
}
