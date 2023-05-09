using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NanaMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public Transform centrePoint;

    public WinConditions winConditionsScript;
    public GameObject player;
    public float radius;
    [Range(0, 360)]
    public float angle;
    public bool canSeePlayer = false;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public GameObject safePointNana;
    public GameObject[] routPoints;
    private GameObject[] objectsForChase;
    private bool[] checkBrokenObject;
    private int currentRoutPoint;
    private Vector3 currentBrokenObject;

    private bool chaseBrokenObject = false;
    private bool nanaReturnToSafe = false;
    private Animator nanaAnimation;


    void Start()
    {
        nanaAnimation = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        agent = GetComponent<NavMeshAgent>();
        objectsForChase = winConditionsScript.brokenObjectsInScene;
        checkBrokenObject = new bool[objectsForChase.Length];
        currentRoutPoint = 0;
        agent.SetDestination(safePointNana.transform.position);

    }
    //basically , this is a better performance for find a player, we set a courotine that makes five 5 times per second, not everytime.
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        // the circle around de enemy that detects object with a targetmask
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //if has anything in the circle
        if (rangeChecks.Length != 0)
        {
            // find the target and return the first position in array collider ( cause we only need one object)
            Transform target = rangeChecks[0].transform;
            //player position minus enemy
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //if is exactly in the middle nad enemy is looking forward
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);


                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) //se o gato � visto pela av�
                {
                    chaseBrokenObject = false;
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;                    
            }
            else //gato sai da vis�o da av� normalmente
            {
                canSeePlayer = false;
                nanaReturnToSafe = true;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            nanaReturnToSafe = true;
        }
            
    }

    private void Update()
    {
        AnimationsNana();
        MovementNana();
        CheckBrokenObjects();
    }
    private void CheckBrokenObjects()
    {
        for(int i = 0; i < objectsForChase.Length; i++)
        {
            if (objectsForChase[i].GetComponent<BrekableObjects>().IsBrokenStatus() && checkBrokenObject[i] == false)
            {
                currentBrokenObject = objectsForChase[i].GetComponent<Transform>().position;
                checkBrokenObject[i] = true;
                chaseBrokenObject = true;
            }
        }
    }

    private void MovementNana()
    {
        if (nanaReturnToSafe)
        {
            agent.speed = 0.7f;
            nanaReturnToSafe = false;
            agent.SetDestination(safePointNana.transform.position);
            currentRoutPoint = 0;
        }
        else if (!canSeePlayer && !chaseBrokenObject)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (currentRoutPoint == routPoints.Length)
                {
                    currentRoutPoint = 0;
                }
                else
                {
                    agent.SetDestination(routPoints[currentRoutPoint].transform.position);
                    agent.speed = 0.7f;
                    currentRoutPoint++;
                }
            }
        }
        else if (chaseBrokenObject)
        {
            agent.SetDestination(currentBrokenObject);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                chaseBrokenObject = false;
                nanaReturnToSafe = true;
            }

        }
        else
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 2.1f;      
        }
    }

    private void AnimationsNana()
    {
        if (agent.isStopped == true)
            nanaAnimation.SetInteger("transition", 0);
        else if (canSeePlayer)
            nanaAnimation.SetInteger("transition", 2);
        else
            nanaAnimation.SetInteger("transition", 1);
    }

    public bool NanaIsStopped()
    {
        return agent.isStopped;
    }

    public void NanaCanMove()
    {
        agent.isStopped = false;
    }

    public void NanaCantMove()
    {
        agent.isStopped = true;
    }

}