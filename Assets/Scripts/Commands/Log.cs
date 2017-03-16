using UnityEngine;

public class Log : Command
{
    public override int Cost
    {
        get
        {
            return 0;
        }
    }

    public override void Execute(Character character)
    {
        Debug.Log ("Executed");
        OnFinished ();
    }
}