using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(CharacterMovement))]
[RequireComponent (typeof(AttackHandler))]
public class Character : MonoBehaviour 
{
	private Health health;
	private CharacterMovement controller;
	private AttackHandler attacks;

	private void Awake ()
	{
		health = GetComponent<Health> ();
		controller = GetComponent<CharacterMovement> ();
		attacks = GetComponent<AttackHandler> ();
	}

	public void Move (Vector3 targetPosition, Action onFinished)
	{
		Debug.Log (string.Format("Move: {0}", targetPosition));
		controller.Move (targetPosition);
		StartCoroutine (WaitForMoveCompleted (onFinished));
	}

	private IEnumerator WaitForMoveCompleted (Action onFinished)
	{
		while (controller.IsMoving)
			yield return new WaitForSeconds (0.5f);
		onFinished ();
	}

	public void Shoot (Vector3 direction, Action onFinished)
	{
		Debug.Log (string.Format("Slash: {0}", direction));
		attacks.Shoot (direction);
		onFinished ();
	}

	public void Explode (Action onFinished)
	{
		Debug.Log ("Explode");
		attacks.Explode ();
		onFinished ();
	}

	public void ApplyDamage (float damagePoints)
	{
		Debug.Log (string.Format("Damage: {0}", damagePoints));
		health.ApplyDamage (damagePoints);
	}

}
