using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    [SerializeField] private Text lifeText,
        scoreText;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject gameOver;
    
    private BoxCollider2D goalCollider;
    
    private int maxLife = 3,
        score;

    public int Score
    {
        get => score;
        set => score = value;
    }

    private void Start()
    {
        goalCollider = GetComponent<BoxCollider2D>();
        
        goalCollider.size = new Vector2(Screen.width, 200f);
        UpdateLifeText();
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If impostor, ...
        if (other.CompareTag("Impostor"))
        {
            maxLife -= 1; // Subtract maxLife
            
            if (maxLife < 0)
            {
                spawner.GameOver = true;
                gameOver.SetActive(true);
            }
            else
                UpdateLifeText();
        }
        // If crewMates, ...
        else if (other.CompareTag("CrewMate"))
        {
            score += 10; // Add score
            UpdateScoreText();
        }
        Destroy(other.gameObject);
    }

    private void UpdateLifeText()
    {
        lifeText.text = maxLife.ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
