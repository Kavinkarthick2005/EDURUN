using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + score;
        }
}
