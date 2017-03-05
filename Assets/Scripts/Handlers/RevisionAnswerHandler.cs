using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Handlers
{
    public static class RevisionAnswerHandler
    {
        public static bool IsCorrect(string selectedAnswer, List<string> possibleWrongAnswers, Text component)
        {
            if (component.name == "Answer")
            {
                if (component.text == selectedAnswer) //correct
                {
                    Debug.Log("Correct!!!");
                    return true;
                    //ToDo: update api

                }
                if (possibleWrongAnswers.Contains(component.text)) //wrong
                {
                    Debug.Log("Wrong!!!");
                    return false;                    
                }
            }

            return false;
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
