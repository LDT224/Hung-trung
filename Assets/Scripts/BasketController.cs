using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    Vector3 mousePos;
    public float speed;
    private float maxX = 7.75f;
    private float minX = -7.75f;
    private GameObject gameController;
    public GameObject[] heart;
    public int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    void Move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos = Camera.main.ScreenToViewportPoint(mousePos);
        mousePos = new Vector3(Mathf.Clamp(mousePos.x,minX,maxX), transform.position.y, 0);
        transform.position = Vector3.Lerp(transform.position, mousePos, speed*Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("egg"))
        {
            Destroy(other.gameObject);
            gameController.GetComponent<GameController>().GetPoint();
        }

        if (other.gameObject.CompareTag("shit"))
        {
            Destroy (other.gameObject);
            count++;
            if(count == 2)
            {
                Debug.Log("Lose");
            }
            Destroy(heart[count]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
