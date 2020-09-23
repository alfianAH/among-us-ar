using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Sprite[] crewMates, impostors;
    [SerializeField] private GameObject imageHolder;
    [SerializeField] private bool isStarting,
        gameOver;
    
    private BoxCollider2D spawnerCollider;

    public bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    public bool IsStarting
    {
        get => isStarting;
        set => isStarting = value;
    }
    
    private void Start()
    {
        spawnerCollider = GetComponent<BoxCollider2D>();
        
        // Set size of spawner collider
        spawnerCollider.size = new Vector2(Screen.width, 100);
    }

    private void Update()
    {
        if (isStarting && !gameOver)
        {
            StartCoroutine(SpawnDelay(1f));
        }
    }

    private void SpawnPictures()
    {
        // Set random xAxis
        float xAxis = Random.Range(0, Screen.width);
        
        // Duplicate image holder
        GameObject imageHolderDuplicate = Instantiate(imageHolder,
            new Vector3(xAxis, transform.position.y), 
            Quaternion.identity, 
            transform.parent);
        
        imageHolderDuplicate.SetActive(true);
        
        // Get image component
        Image imageHolderSprite = imageHolderDuplicate.GetComponent<Image>();
        
        // Set random sprite
        int randomNumber = Random.Range(0, 2);
        int randomIndex;
        switch (randomNumber)
        {
            case 0: // 0 is crewMate
                randomIndex = Random.Range(0, crewMates.Length);
                imageHolderSprite.sprite = crewMates[randomIndex]; // Set sprite
                imageHolderDuplicate.tag = "CrewMate";
                break;
            case 1: // 1 is impostor
                randomIndex = Random.Range(0, impostors.Length);
                imageHolderSprite.sprite = impostors[randomIndex]; // Set sprite
                imageHolderDuplicate.tag = "Impostor";
                break;
        }
    }
    
    private IEnumerator SpawnDelay(float delay)
    {
        SpawnPictures();
        isStarting = false;
        
        yield return new WaitForSeconds(delay);
        
        isStarting = true;
    }
}
