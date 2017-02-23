using System;

public abstract class Command
{
    public event Action OnCompleted;
    public abstract int Cost { get; }
    
    public abstract void Execute ();
    
    public void OnFinished ()
    {
         if (OnCompleted!=null)
            OnCompleted ();
    }
}