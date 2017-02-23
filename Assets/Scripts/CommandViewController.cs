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

		private void Start ()
		{
			options.SetOptions<ActionType>();
			addAction.onClick.AddListener (AddSelectedAction);
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))
				controller.ExecuteActions ();
		}

		private void AddSelectedAction ()
		{
			ActionType selected = options.GetValue<ActionType> ();
			switch (selected)
			{
				case ActionType.Log:
					TryAddAction (new Log ());
					break;
				default:
					break;
			}
		}

		private void TryAddAction (Command toAdd)
		{
			bool wasAdded = controller.TryAddAction (toAdd);
			Debug.Log (string.Format ("The command was added {0}", wasAdded));
		}

	}
}