using UnityEngine;

public class Log : Command
{
    public Log(Character character) : base(character)
    {
    }

    public override int Cost
    {
        get
        {
            return 0;
        }
    }

    public override void Execute()
    {
        Debug.Log ("Executed");
        OnFinished ();
    }
}