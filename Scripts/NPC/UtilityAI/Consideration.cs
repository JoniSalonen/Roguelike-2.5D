using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI
{
    public abstract class Consideration : ScriptableObject
    {
        public string considirationName;
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

        public virtual void Awake()
        {
            _score = 0;

        }

        public abstract float ScoreConsideration();
    }
}

