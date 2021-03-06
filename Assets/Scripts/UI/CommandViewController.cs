﻿using System.Collections.Generic;
using UnityEngine;

public class CommandViewController : MonoBehaviour 
{
	[SerializeField]
	private Controller controller;
	[SerializeField]
	private Character character;
	[SerializeField]
	private LayerMask terrain;
	[SerializeField]
	private PreviewAgent preview;
	private UIStateBase current;
    private Dictionary<ActionType, UIStateBase> states;

	public PreviewAgent Preview
	{
		get
		{
			return preview;
		}
	}

	public int RemainingActionPoints
	{
		get
		{
			return controller.RemainingActionPoints;
		}
	}

	private void Awake ()
	{
		states = new Dictionary<ActionType, UIStateBase> ();
	}

	private void Start ()
	{
		SetState (ActionType.None);
		states.Add (ActionType.Move, new MoveUIState (this));
		SyncPreview ();
		controller.OnFinished += SyncPreview;
	}	

	private void Update ()
	{
		if (current == null) return;
		Vector3 position = GetCurrentPosition ();
		current.OnMousePositionChanged (position);
		if (Input.GetMouseButtonDown (0))
			current.OnClick (position);
	}

    public void SetState(ActionType state)
    {
		if (current != null)
			current.Disable ();
		if (states.TryGetValue (state, out current))
			current.Enable ();
    }

	public bool TryAddAction (Command toAdd)
	{
		bool wasAdded = controller.TryAddAction (toAdd);
		Debug.Log (string.Format ("The command was added {1}: {0} - {2}", wasAdded, toAdd.GetType ().Name, toAdd.Cost));
		return wasAdded;
	}

	public void RunActions ()
	{
		current = null;
		controller.ExecuteActions ();
	}

	private Vector3 GetCurrentDirection()
	{
		Vector3 position = GetCurrentPosition ();
		Vector3 distance = position - character.transform.position;
		distance.y = 0f;
		return distance.normalized;
	}

	private Vector3 GetCurrentPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		bool didHit = Physics.Raycast (ray, out hit);
		return didHit? hit.point : character.transform.position; 
	}

	private void SyncPreview ()
	{
		Preview.Sync (character);
	}
}