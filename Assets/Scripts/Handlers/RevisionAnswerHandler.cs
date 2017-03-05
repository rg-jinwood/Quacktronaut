using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Handlers
{
    public static class RevisionAnswerHandler
    {
        public static void IsCorrectAnswer()
        {

        }

        public static string GenerateAnswer(RevisionDatum datum)
        {
            if(Random.Range(0,2) == 1)
            {
                //give the correct answer
                return datum.translation.text;
            }
            return datum.wrong_answers[Random.Range(0, datum.wrong_answers.Count - 1)];
        }
    }
}
