using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float lives=3;
    [SerializeField]
    private float score;
    [SerializeField]
    private TextMeshProUGUI scoret;
    [SerializeField]
    private TextMeshProUGUI livesText;
    public GameObject gover;
    public GameObject ywin;
    int brickcount;
    public Transform player;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = player.position;
        brickcount = FindObjectOfType<BrickSpawnner>().transform.childCount;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 8f;
        
        
        
       
        
    }
   


    void Update()
    {
        if(transform.position.y<-5.78)
        {
           
            lives = lives - 1;
            transform.position = Vector3.zero;
            rb.velocity = Vector3.down*8f;
            player.position = startPos;

        }
        if(lives<0)
        {
            GameOver();
        }
        scoret.text = "" + score;
        livesText.text = "" + lives;
      

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            score = score + 5;
            scoret.text = score.ToString("Score");
            brickcount++;
                if(brickcount>=32)
            {
                ywin.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
       

    }
    void GameOver()
    {
        gover.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
        

    }
}
