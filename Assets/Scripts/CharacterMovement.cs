using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class CharacterMovement : MonoBehaviour 
{
	private NavMeshAgent agent;

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
	}
	public void Move (Vector3 position)
	{
		agent.SetDestination (position);
	}
}
