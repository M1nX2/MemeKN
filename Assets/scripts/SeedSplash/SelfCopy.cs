using UnityEngine;

public class SelfCopy : MonoBehaviour
{
    private GameObject myCanvas;
    private Game game;
    private float timer = 0f; // таймер для отсчета времени
    private float copyInterval = 3f; // интервал времени между копированием объекта
    private void Start()
    {
        myCanvas = GameObject.Find("Canvas");
        game = myCanvas.GetComponent<Game>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= copyInterval-game.timeLeft/20)
        {
            timer = 0;

            float randomOffsetX = Random.Range(-50f, 1000f); // генерируем случайное отклонение по X
            float randomOffsetY = Random.Range(-50f, 50f); // генерируем случайное отклонение по Y
            Vector2 randomOffset = new Vector2(randomOffsetX, randomOffsetY);
            Vector2 randomPosition = (Vector2)transform.position + randomOffset;
            

            float randomScaleX = Random.Range(100f, 150f); // генерируем случайный масштаб по X
            float randomScaleY = Random.Range(75f, 150f); // генерируем случайный масштаб по Y
            Vector2 randomScale = new Vector2(randomScaleX, randomScaleY);

            GameObject copy = Instantiate(gameObject, randomPosition, Quaternion.identity);
            copy.transform.localScale = randomScale; // задаем случайный масштаб
            copy.AddComponent<Move>();
            Destroy(copy.GetComponent<SelfCopy>());
        }
    }
}
