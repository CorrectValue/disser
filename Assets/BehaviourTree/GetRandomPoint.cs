using UnityEngine;

namespace BehaviourTrees
{
    public class GetRandomPoint : BaseBehaviourTreeNode
    {
        public OutVariable<Vector3> Output { get; set; }
        public InVariable<float> Radius { get; set; } = 5f;
        public InVariable<Vector3> Center { get; set; } = Vector3.zero;

        protected override NodeState OnStart(ExecutionContext context)
        {
            var p = Random.insideUnitCircle * Radius;
            Output.Set(Center + new Vector3(p.x, 2.0f, p.y));

            return NodeState.Success;
        }
    }
}