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
			options.SetOptions<ActionType> ();
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
				case ActionType.Shoot:
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
			TryAddAction (new Shoot (character, direction));
        }

        private Vector3 GetCurrentDirection()
        {
			Vector3 position = GetCurrentPosition ();
			Vector3 distance = position - character.transform.position;
			distance.y = 0f;
			return distance.normalized;
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