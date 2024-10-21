using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIAutoGameTester : MonoBehaviour
{
    private int maxGame;
    private List<float> score1; 
    private List<float> score2; 

    public TMP_Text gamCounter;
    public TMP_Text character1Score;
    public TMP_Text character2Score;
    public TMP_Text character1TotalScore;
    public TMP_Text character2TotalScore;
    public TMP_Text diff;
    public void Start()
    {
        maxGame = 10;
        score1 = new List<float>();
        score2 = new List<float>();
    }

    // Update is called once per frame
    public void UpdateText(float s1, float s2, int index){
        this.score1.Add(s1);
        this.score2.Add(s2);
        string t1 = "";
        string t2 = "";
        string gID = "";

        int startIndex = (int)Mathf.Max(score1.Count-10, 0f);
        int endIndex = (int)Mathf.Min(score1.Count, startIndex+10);
        for (int i = startIndex; i < endIndex; i++)
        {
            if(i == startIndex) {
                t1 += score1[i].ToString("F2");
                t2 += score2[i].ToString("F2");
                gID += "Game"+i.ToString();
            }
            else{
                t1 += "\n" + score1[i].ToString("F2");
                t2 += "\n" + score2[i].ToString("F2");
                gID += "\nGame"+i.ToString();
            }
        }
        character1Score.text = t1;
        character2Score.text = t2;
        gamCounter.text = gID;
        
        //CalcTotal

        float total1 = score1.Sum();
        float total2 = score2.Sum();
        float dif = Mathf.Max(total1, total2) - Mathf.Min(total1, total2);
        character1TotalScore.text = total1.ToString("F1");
        character2TotalScore.text = total2.ToString("F1");
        string characterIndicator = (total1 > total2) ? "(1) " : "(2) ";
        diff.text = characterIndicator + dif.ToString("F1");


    }
}
