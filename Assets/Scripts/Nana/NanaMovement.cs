using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class NanaMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    public WinConditions winConditionsScript;
    public GameObject player;

    [Header("Visão da avó")]
    public float radius;
    [Range(0, 360)]
    public float angle;
    public bool canSeePlayer = false;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [Header("Rota da avó")]
    public GameObject safePointNana;
    public GameObject[] routPoints;
    [SerializeField] private float stopDistanceGap;
    [SerializeField] private float nanaWalkVelocity;
    [SerializeField] private float nanaRunVelocity;


    private GameObject[] objectsForChase;
    private bool[] checkBrokenObject;
    private int currentRoutPoint;
    private Vector3 currentBrokenObject;

    private bool chaseBrokenObject = false;
    private bool nanaReturnToSafe = false;
    private bool nanaSeeCat = false;
    
    [SerializeField]
    private Animator nanaAnimation;

    public UnityEvent OnNanaHearObject;
    public UnityEvent OnNanaSeeinCat;
    public UnityEvent OnNanaSeeCat;




    void Start()
    {
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


                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))//se o gato é visto pela avó
                {
                    canSeePlayer = true;
                    chaseBrokenObject = false;
                    OnNanaSeeinCat?.Invoke();

                    if(!nanaSeeCat)
                    {
                        nanaSeeCat = true;
                        OnNanaSeeCat?.Invoke();
                    }
                }             
                else
                {
                    nanaSeeCat = false;
                    canSeePlayer = false;
                }
            }
            else //gato sai da visão da avó normalmente
            {
                nanaSeeCat = false;
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            nanaSeeCat = false;
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
                OnNanaHearObject?.Invoke();
            }
        }
    }

    private void MovementNana()
    {
        agent.stoppingDistance = stopDistanceGap; //Pra ter certeza que ela vai alcançar todos os pontos de rota/safe points no terreno.

        if (nanaReturnToSafe)
        {
            agent.speed = nanaWalkVelocity;
            nanaReturnToSafe = false;
            agent.SetDestination(safePointNana.transform.position);
            transform.LookAt(safePointNana.transform.position);
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
                    transform.LookAt(routPoints[currentRoutPoint].transform.position);
                    agent.speed = nanaWalkVelocity;
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
        else if (!agent.isStopped)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            agent.stoppingDistance = 0f; // pra ter certeza de que ela vai chegar até a posição do gato.
            agent.SetDestination(player.transform.position);
            agent.speed = nanaRunVelocity;      
        }
    }

    private void AnimationsNana()
    {
        if (agent.isStopped)
            nanaAnimation.SetInteger("transition", 3);
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