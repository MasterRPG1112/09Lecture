using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Target;

    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Target != null)
        {
            nav.SetDestination(Target.position);
        }
    }
}
