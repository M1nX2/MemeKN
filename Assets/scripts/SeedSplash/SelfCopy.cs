using UnityEngine;

public class SelfCopy : MonoBehaviour
{
    private GameObject myCanvas;
    private Game game;
    private float timer = 0f; // ������ ��� ������� �������
    private float copyInterval = 3f; // �������� ������� ����� ������������ �������
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

            float randomOffsetX = Random.Range(-50f, 1000f); // ���������� ��������� ���������� �� X
            float randomOffsetY = Random.Range(-50f, 50f); // ���������� ��������� ���������� �� Y
            Vector2 randomOffset = new Vector2(randomOffsetX, randomOffsetY);
            Vector2 randomPosition = (Vector2)transform.position + randomOffset;
            

            float randomScaleX = Random.Range(100f, 150f); // ���������� ��������� ������� �� X
            float randomScaleY = Random.Range(75f, 150f); // ���������� ��������� ������� �� Y
            Vector2 randomScale = new Vector2(randomScaleX, randomScaleY);

            GameObject copy = Instantiate(gameObject, randomPosition, Quaternion.identity);
            copy.transform.localScale = randomScale; // ������ ��������� �������
            copy.AddComponent<Move>();
            Destroy(copy.GetComponent<SelfCopy>());
        }
    }
}
