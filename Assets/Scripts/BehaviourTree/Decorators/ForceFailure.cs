using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class ForceFailure : Node
    {
        public ForceFailure() : base() { }
        public ForceFailure(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        return NodeState.FAILURE;
                }
            }
            return anyChildIsRunning ? NodeState.RUNNING : NodeState.FAILURE;
        }
    }
}
