using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovement : MonoBehaviour
{
	public LayerMask groundLayer;
	public RayCastGun laserScript;
	private NavMeshAgent agent;
	private Animator catAnimation;
	private Rigidbody catRigidBody;
	private bool hasJumped = false;

	[SerializeField] private float jumpForce = 5f;
	[SerializeField] private float resetTimeJump;
	[SerializeField] private float resetAgent;

	public float radius;




	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		catAnimation = GetComponent<Animator>();
		catRigidBody = GetComponent<Rigidbody>();
	}

    private void Update()
	{
		Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Input.GetMouseButton(0))
		{

			SetTypeMovement(screenRay);
		}
		else
		{
			if (agent.isOnNavMesh)
				agent.isStopped = true;

			catAnimation.SetInteger("transition", 0);
		}
	}

	private void SetTypeMovement(Ray screenRay)
    {
		if (agent.isOnNavMesh)
		{
			agent.isStopped = false;
			RaycastHit hit;

			if (Physics.Raycast(screenRay, out hit, Mathf.Infinity, groundLayer))
			{
				Vector3 agentPos = agent.transform.position;
				Vector3 hitPos = hit.point;
				hitPos.y = agentPos.y; // Mantém a mesma altura do agente para o cálculo de distância
				float distance = Vector3.Distance(agentPos, hitPos);
				
				if (distance <= radius && laserScript.currentLaser == LasersTypes.laserRed)
				{
					catAnimation.SetInteger("transition", 1);
					agent.SetDestination(hit.point);
				}
				else if ((distance <= radius + 0.3f) && laserScript.currentLaser == LasersTypes.laserBlue && !hasJumped)
                {
					JumpToClick();
					catAnimation.SetInteger("transition", 2);
					hasJumped = true;
				}
				else //Para o gato. Caso o jogador continue segurando o mouse e saia do raio do laser.
                {
					catAnimation.SetInteger("transition", 0);
					agent.isStopped = true;
				}
			}
		}
	}

	private void JumpToClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			Vector3 jumpDirection = hit.point - transform.position;
			jumpDirection.y = 2f;
			catRigidBody.AddForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);
			transform.LookAt(hit.point);
			agent.enabled = false;
			Invoke("ResetHasJumped", resetTimeJump);
			Invoke("ResetAgent", resetTimeJump);

		}

	}

	private void ResetAgent()
	{
		agent.enabled = true;
	}

	private void ResetHasJumped()
	{
		hasJumped = false;
		agent.enabled = true;
	}
}
