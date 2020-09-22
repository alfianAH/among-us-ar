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
            isStarting = false;
            SpawnPictures();
        }
    }

    private void SpawnPictures()
    {
        // Duplicate image holder
        GameObject imageHolderDuplicate = Instantiate(imageHolder, transform.position, Quaternion.identity, transform.parent);
        // Get image component
        Image imageHolderSprite = imageHolderDuplicate.GetComponent<Image>();
        
        imageHolderSprite.sprite = crewMates[0]; // Set sprite
    }
}
