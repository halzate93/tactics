using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class RigidbodyController : MonoBehaviour 
{
	private new Rigidbody rigidbody;

	private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	public void AddForce (Vector3 force)
	{
		rigidbody.AddForce (force);
	}

	public void Move (Vector3 position)
	{
		rigidbody.MovePosition (position);
	}
}
