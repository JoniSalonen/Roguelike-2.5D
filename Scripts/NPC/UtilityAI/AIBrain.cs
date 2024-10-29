using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Core;

namespace UtilityAI
{

    public class AIBrain : MonoBehaviour
    {

        public Action bestAction { get; set; }
        private NPCController npc;

        void Start()
        {
            npc = GetComponent<NPCController>();


        }

        // Update is called once per frame
        void Update()
        {

        }

        // Decide the best action to take based on the available actions and their scores
        // The best action is the one with the highest score
        public void DecideBestAction(Action[] actionsAvailable) 
        { 
            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionsAvailable.Length; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].score;
                }
            }

            bestAction = actionsAvailable[nextBestActionIndex];

        }

        // Loop through all the considerations of an action and calculate the overall score
        // The overall score is the product of all the consideration scores 
        public float ScoreAction(Action action) 
        {
            float score = 1f;     
            for (int i = 0; i < action.considirations.Length; i++)
            {
                float considerationScore = action.considirations[i].ScoreConsideration();
                score *= considerationScore;

                if (score == 0)
                {
                    action.score = 0;
                    return action.score; // No need to continue if the score is 0
                }
            }

            // Averaging scheme of overall score
            float originalScore = score;
            float modFactor = 1 - (1 / action.considirations.Length);
            float makeupValue = (1- originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;

        }
    }
}