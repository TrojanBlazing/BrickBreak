using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float h;
   

    void Start()
    {
      
       
    }

   
    void Update()
    {
        Move();
    }
    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right*h*speed * Time.deltaTime);
        
        if(transform.position.x>7.57f)
        {
            transform.position = new Vector3(7.57f, transform.position.y, 0);
        }
        if (transform.position.x <-7.57f)
        {
            transform.position = new Vector3(-7.57f, transform.position.y, 0);
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

}
