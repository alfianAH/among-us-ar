using UnityEngine;
using UnityEngine.EventSystems;

public class ImageHolder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GoalController goalController;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float speed;

    private void Update()
    {
        if(spawner.GameOver) return;
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.CompareTag("CrewMate"))
        {
            goalController.Score -= 10;
            goalController.UpdateScoreText();
        }
        Destroy(gameObject);
    }
}
