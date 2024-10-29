using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class MoveController : MonoBehaviour
    {
        private NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MoveTo(Vector3 position)
        {
            agent.destination = position;
        }
    }
}