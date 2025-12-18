using UnityEngine;
using TMPro;

public class FoundDocs : MonoBehaviour
{

    [SerializeField] private TMP_Text totalText;
    [SerializeField] private TMP_Text sentenceText;

    void Start()
    {
        int totalDocs = GameStats.Documents;
        int totalSentence = CalculateSentence(totalDocs);

        totalText.SetText("The IRS Found " + totalDocs + " Documents!");
        sentenceText.SetText("Total Sentence: " + totalSentence + " Years");
    }

    private int CalculateSentence(int totalDocs)
    {
        return totalDocs * 5;
    }

}
