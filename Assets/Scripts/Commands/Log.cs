using System;
using UnityEngine;

public class Log : Command
{
    public override int Cost
    {
        get
        {
            return 1;
        }
    }

    public event Action OnCompleted;

    public override void Execute()
    {
        Debug.Log ("Executed");
        OnFinished ();
    }
}