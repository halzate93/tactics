public class Explode : Command 
{
    public Explode(Character character) : base(character)
    {
    }

    public override int Cost
    {
        get
        {
            return 5;
        }
    }

    public override void Execute()
    {
		character.Explode (OnFinished);
    }
}
