using UnityEngine;

namespace BehaviourTrees
{
    public abstract class ExecutionContext
    {
    }

    public class SimpleContext : ExecutionContext
    {
        public GameObject Actor { get; }

        public SimpleContext(GameObject actor)
        {
            Actor = actor;
        }
    }
}
