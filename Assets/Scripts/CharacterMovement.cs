using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class CharacterMovement : MonoBehaviour 
{
	private NavMeshAgent agent;
	private Animator animator;

	public bool IsMoving
	{
		get
		{
			return agent.pathPending || agent.remainingDistance > agent.stoppingDistance;
		}
	}

	private void Awake ()
	{
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	
	private void Update ()
	{
		float speed = IsMoving? 1f : 0f;
		animator.SetFloat ("Speed", speed);
	}

	public void Move (Vector3 position)
	{
		agent.SetDestination (position);
	}
}
