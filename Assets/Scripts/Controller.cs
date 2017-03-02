using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Character))]
public class Controller: MonoBehaviour
{
    [SerializeField]
    private int actionPoints = 10;
    private bool isExecuting;
    public int CurrentActionPoints
    {
        get; private set; 
    }

    private Queue<Command> actions;

    private void Awake ()
    {
        actions = new Queue<Command> ();
    }

    private void Start ()
    {
        Reset ();
    }

    public void ExecuteActions ()
    {
        isExecuting = true;
        ExecuteNextAction ();
    }

    public bool TryAddAction (Command action)
    {
        if (!isExecuting && CurrentActionPoints >= action.Cost)
        {
            actions.Enqueue (action);
            CurrentActionPoints -= action.Cost;
            return true;
        }
        else
            return false;
    }

    private void ExecuteNextAction ()
    {
        if (actions.Count == 0)
        {
            Reset ();
            return;
        }
        Command next = actions.Dequeue ();
        next.OnCompleted += ExecuteNextAction;
        next.Execute ();
    }

    private void Reset ()
    {
        isExecuting = false;
        CurrentActionPoints = actionPoints;
    }
}