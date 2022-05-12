using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private GameObject basketController;
    // Start is called before the first frame update
    void Start()
    {
        basketController = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("egg"))
        {
            basketController.GetComponent<BasketController>().count++;
            if (basketController.GetComponent<BasketController>().count == 2)
            {
                Debug.Log("Lose");
            }
            Destroy(basketController.GetComponent<BasketController>().heart[basketController.GetComponent<BasketController>().count]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
