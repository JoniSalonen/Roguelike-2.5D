using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
using Core;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Heal", menuName = "UtilityAI/Actions/HealUnits")]
    public class HealUnits : Action
    {
        public override void Execute(NPCController npc)
        {
            npc.HealUnits(2);
        }

    }
}
