using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class PreviewAgent: MonoBehaviour
{
    [SerializeField]
    private float distancePerUnit;
    [SerializeField]
    private TrailPath trail;
    private NavMeshAgent agent;
    private new Renderer renderer;
    private Vector3 startPosition;

    private void Awake ()
    {
        renderer = GetComponent<Renderer> ();
        agent = GetComponent<NavMeshAgent> ();
    }

    private void Start ()
    {
        agent.Stop ();
    }

    public void Sync (Character character)
    {
        transform.position = character.transform.position;
        startPosition = transform.position;
        trail.Clear ();
        trail.AddPosition (startPosition);
    }

    public void SetPosition (Vector3 position)
    {
        agent.Warp (position);
    }

    public void SetColor (Color color)
    {
        renderer.material.color = color;
    }

    public int GetCostTo (Vector3 position)
    {
        agent.SetDestination (position);
        float distance = agent.remainingDistance;
        return (int) (distance / distancePerUnit);
    }

    public void AddTrailPosition (Vector3 position)
    {
        trail.AddPosition (position);
    }
}