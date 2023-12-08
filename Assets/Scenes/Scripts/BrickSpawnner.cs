using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSpawnner : MonoBehaviour
{
    [SerializeField] 
    private Vector2Int size;
    [SerializeField] 
    private Vector2 offset;
    [SerializeField]
    private GameObject spawnnerprefab;
    

    void Awake()
    {
        for(int i=0;i<size.x;i++)
        {
            for(int j=0;j<size.x;j++)
            {
                GameObject ne = Instantiate(spawnnerprefab, transform) ;
                ne.transform.position = transform.position + new Vector3(i * offset.x, j * offset.y, 0);
           
            }
        }
        
    }
    private void Start()
    {
       

    }


    void Update()
    {
        
    }
   public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
