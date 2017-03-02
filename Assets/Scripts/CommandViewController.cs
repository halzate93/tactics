using System;
using UnityEngine;
using UnityEngine.UI;

namespace Structures
{
	public class CommandViewController : MonoBehaviour 
	{
		[SerializeField]
		private Controller controller;
		[SerializeField]
		private Dropdown options;
		[SerializeField]
		private Button addAction;
		[SerializeField]
		private Character character;
		[SerializeField]
		private LayerMask terrain;

		private void Start ()
		{
			options.SetOptions<ActionType>();
			addAction.onClick.AddListener (AddSelectedAction);
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.A))
				AddSelectedAction ();
			if (Input.GetKeyDown (KeyCode.Space))
				controller.ExecuteActions ();
		}

		private void AddSelectedAction ()
		{
			ActionType selected = options.GetValue<ActionType> ();
			switch (selected)
			{
				case ActionType.Log:
					TryAddAction (new Log (character));
					break;
				case ActionType.Move:
					AddMove ();
					break;
				case ActionType.Slash:
					AddSlash ();
					break;
				case ActionType.Explode:
					TryAddAction (new Explode (character));
					break;
				default:
					break;
			}
		}

        private void AddSlash()
        {
            Vector3 direction = GetCurrentDirection ();
			TryAddAction (new Slash (character, direction));
        }

        private Vector3 GetCurrentDirection()
        {
			Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 direction = (Vector2)Input.mousePosition - center;
			return new Vector3 (direction.x, 0f, direction.y).normalized;
        }

        private void AddMove()
        {
			Vector3 position = GetCurrentPosition ();
			TryAddAction (new Move (character, position));	
        }

        private Vector3 GetCurrentPosition()
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			bool didHit = Physics.Raycast (ray, out hit);
			return didHit? hit.point : character.transform.position; 
        }

        private void TryAddAction (Command toAdd)
		{
			bool wasAdded = controller.TryAddAction (toAdd);
			Debug.Log (string.Format ("The command was added {1}: {0} - {2}", wasAdded, toAdd.GetType ().Name, toAdd.Cost));
		}

	}
}