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
            foreach (Node node in children)
            {
                node.Evaluate();
            }
            return NodeState.FAILURE;
        }
    }
}
