using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f; // Скорость движения объекта
                               // Количество жизней
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
        // Проверяем, достиг ли объект края камеры
        if (transform.position.x + objectWidth / 2f < mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect)
        {
            
            // Если достиг, уменьшаем количество жизней и удаляем объект
            game.GetDamage();
            Destroy(gameObject);
        }
        else
        {
            // Если не достиг, двигаем объект влево
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime*500*((game.timeLeft+10))/3, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        // При нажатии на объект удаляем его
        game.GetPoint();
        Destroy(gameObject);
    }
}
