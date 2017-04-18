using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (TrailRenderer))]
public class TrailPath : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float snapDistance;
	private List<Vector3> positions;
	private int current = 0;
	private new TrailRenderer renderer;

	private void Awake ()
	{
		positions = new List<Vector3> ();
		renderer = GetComponent<TrailRenderer> ();
	}
	
	private void Start ()
	{
		if (positions.Count != 0)
			transform.position = positions [0];
	}

	private void Update () 
	{
		if (positions.Count < 2) return;
		Vector3 direction = GetCurrentDirection ();
		transform.Translate (direction * (speed * Time.deltaTime));
		if (CheckIsCloseEnough ())
			Next ();
	}

	public void AddPosition (Vector3 position)
	{
		positions.Add (position);
	}	

	public void Clear ()
	{
		positions.Clear ();
	}

	private Vector3 GetCurrentDirection ()
	{
		Vector3 destination = positions[current + 1];
		Vector3 distance = destination - transform.position;
		return distance.normalized;
	}

	private bool CheckIsCloseEnough ()
	{
		Vector3 destination = positions[current + 1];
		float sqrDistance = (destination - transform.position).sqrMagnitude;
		return sqrDistance <= snapDistance * snapDistance;
	}

	private void Next ()
	{
		current ++;
		if (current == positions.Count - 1)
			current = 0;

		transform.position = positions [current];
		renderer.Clear ();
	}
}