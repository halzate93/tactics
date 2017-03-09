using UnityEngine;

public class Shoot: Command 
{
	private Vector3 direction;

    public Shoot(Character character, Vector3 direction) : base(character)
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
        character.Shoot (direction, OnFinished);
    }
}
