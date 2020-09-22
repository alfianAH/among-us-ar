using UnityEngine;
using UnityEngine.EventSystems;

public class ImageHolder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
