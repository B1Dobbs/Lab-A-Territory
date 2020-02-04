using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCountUp : MonoBehaviour
{
    public string whichScore;
    float targetScore;
    float startScore = 0f;
    int nonfloatScore;
    public GameObject Fixer;
    public GameObject Breaker;
    // Start is called before the first frame update
    void Start()
    {
        if(whichScore == "FixerPoints") {
            targetScore = Fixer.GetComponent<Player>().points;
            StartCoroutine("CountUpToTarget");
        }
        else if (whichScore == "BreakerPoints") {
            targetScore = Breaker.GetComponent<Player>().points;
            StartCoroutine("CountUpToTarget");
        }
        else if (whichScore == "FixerTerritory") {
            targetScore = Fixer.GetComponent<Player>().territoriesClaimed;
            StartCoroutine("CountUpToTarget");
        }
        else if (whichScore == "BreakerTerritory") {
            targetScore = Breaker.GetComponent<Player>().territoriesClaimed;
            StartCoroutine("CountUpToTarget");
        }
        else if (whichScore == "TotalScoreFixer") {
            targetScore = Fixer.GetComponent<Player>().points + (Fixer.GetComponent<Player>().territoriesClaimed * 10);
            StartCoroutine("CountUpToTarget");
        }
        else if (whichScore == "TotalScoreBreaker") {
            targetScore = Breaker.GetComponent<Player>().points + (Breaker.GetComponent<Player>().territoriesClaimed * 10);
            StartCoroutine("CountUpToTarget");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountUpToTarget() {
        while(startScore < targetScore) {
            startScore += 45 * Time.deltaTime;
            startScore = Mathf.Clamp(startScore, 0f, targetScore);
            nonfloatScore = (int)startScore;
            gameObject.GetComponent<TextMeshProUGUI>().text = nonfloatScore.ToString();
            yield return null;
        }
    }
}
