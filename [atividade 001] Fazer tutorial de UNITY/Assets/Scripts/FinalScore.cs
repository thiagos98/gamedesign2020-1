using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalScore : MonoBehaviour
{
    public Text finalScore;

    void Start(){
        finalScore.text = "Score: " + GameController.instance.totalScore.ToString();
    }
    
}
