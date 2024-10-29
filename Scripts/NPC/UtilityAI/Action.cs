using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Core;


namespace UtilityAI
{
    public abstract class Action : ScriptableObject
    {
        public string actionName;
        public float _score;

        public float score
        {
            get
            {
                return _score;
            }
            set
            {
                this._score = Mathf.Clamp01(value);
            }

        }

        public Consideration[] considirations;

        public virtual void Awake()
        {
            _score = 0;

        }

        public abstract void Execute(NPCController npc);
    }
}