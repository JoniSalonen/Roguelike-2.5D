using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
using Core;

namespace Core
{

    public class NPCController : MonoBehaviour
    {
        public MoveController movement { get; set; }

        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;

        // Start is called before the first frame update
        void Start()
        {
            movement = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #region Coroutines

        public void HealUnits(int time)
        {
            StartCoroutine(HealCoroutine(time));
        }

        public void Attack(int time)
        {
            StartCoroutine(AttackCoroutine(time));
        }

        IEnumerator HealCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {

                yield return new WaitForSeconds(1);
                counter--;
                
            }

            Debug.Log("Healing");

        }
        IEnumerator AttackCoroutine(int time) {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("Attacking");
        }


        #endregion  
    }
}
