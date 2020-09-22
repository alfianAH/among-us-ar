using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Sprite[] crewMates, impostors;
    [SerializeField] private GameObject imageHolder;
    [SerializeField] private bool isStarting;
    
    private BoxCollider2D spawnerCollider;

    private void Start()
    {
        spawnerCollider = GetComponent<BoxCollider2D>();
        
        // Set size of spawner collider
        spawnerCollider.size = new Vector2(Screen.width, 100);
    }

    private void Update()
    {
        if (isStarting)
        {
            StartCoroutine(SpawnDelay(2f));
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
        // Get image component
        Image imageHolderSprite = imageHolderDuplicate.GetComponent<Image>();
        
        // Set random sprite
        int randomNumber = Random.Range(0, 2);
        int randomIndex = Random.Range(0, impostors.Length+1);
        switch (randomNumber)
        {
            case 0:
                imageHolderSprite.sprite = crewMates[randomIndex]; // Set sprite
                break;
            case 1 :
                imageHolderSprite.sprite = impostors[randomIndex]; // Set sprite
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
