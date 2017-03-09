using UnityEngine;

public class Move : Command 
{
	private Vector3 position;

    public Move(Character character, Vector3 position) : base(character)
    {
		this.position = position;
    }

    public override int Cost
    {
        get
        {
            return 1;
        }
    }

    public override void Execute()
    {
        character.Move (position, OnFinished);
    }
}
