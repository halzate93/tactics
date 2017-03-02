using UnityEngine;

public class Slash: Command 
{
	private Vector3 direction;

    public Slash(Character character, Vector3 direction) : base(character)
    {
		this.direction = direction;
    }

    public override int Cost
    {
        get
        {
           return 3;
        }
    }

    public override void Execute()
    {
		character.Slash (direction);
		OnFinished ();
    }
}
