using UnityEngine;

public class ImageHolder : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}
