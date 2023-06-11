using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f; // �������� �������� �������
                               // ���������� ������
    private GameObject myCanvas;
    private Game game;
    private Camera mainCamera;
    private float objectWidth;

    private void Start()
    {
        mainCamera = Camera.main;
        objectWidth = GetComponent<Renderer>().bounds.size.x;
        myCanvas = GameObject.Find("Canvas");
        game = myCanvas.GetComponent<Game>();
}

    private void Update()
    {
        // ���������, ������ �� ������ ���� ������
        if (transform.position.x + objectWidth / 2f < mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect)
        {
            
            // ���� ������, ��������� ���������� ������ � ������� ������
            game.GetDamage();
            Destroy(gameObject);
        }
        else
        {
            // ���� �� ������, ������� ������ �����
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime*500*((game.timeLeft+10))/3, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        // ��� ������� �� ������ ������� ���
        game.GetPoint();
        Destroy(gameObject);
    }
}
