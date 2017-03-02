using System;

public abstract class Command
{
    public event Action OnCompleted;
    protected Character character;
    public abstract int Cost { get; }
    
    public Command (Character character)
    {
        this.character = character;
    }

    public abstract void Execute ();
    
    public void OnFinished ()
    {
         if (OnCompleted!=null)
            OnCompleted ();
    }
}