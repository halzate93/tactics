using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(RigidbodyController))]
[RequireComponent (typeof(AttackHandler))]
public class Character : MonoBehaviour 
{
	private Health health;
	private RigidbodyController controller;
	private AttackHandler attacks;

	private void Awake ()
	{
		health = GetComponent<Health> ();
		controller = GetComponent<RigidbodyController> ();
		attacks = GetComponent<AttackHandler> ();
	}

	public void Move (Vector3 targetPosition)
	{
		Debug.Log (string.Format("Move: {0}", targetPosition));
		controller.Move (targetPosition);		
	}

	public void Slash (Vector3 direction)
	{
		Debug.Log (string.Format("Slash: {0}", direction));
		attacks.Slash ();
	}

	public void Explode ()
	{
		Debug.Log ("Explode");
		attacks.Explode ();
	}

	public void ApplyDamage (float damagePoints)
	{
		Debug.Log (string.Format("Damage: {0}", damagePoints));
		health.ApplyDamage (damagePoints);
	}

}
