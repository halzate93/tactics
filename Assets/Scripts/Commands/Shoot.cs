using UnityEngine;

public class Shoot: Command 
{
	private Vector3 direction;

    public Shoot(Vector3 direction)
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

    public override void Execute(Character character)
    {
        character.Shoot (direction, OnFinished);
    }
}
