public class Explode : Command 
{
    public override int Cost
    {
        get
        {
            return 5;
        }
    }

    public override void Execute(Character character)
    {
		character.Explode (OnFinished);
    }
}
