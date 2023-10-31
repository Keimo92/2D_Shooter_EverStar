using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    SceneManager scenemanager;
    
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
       

        

        if (Input.GetKey(KeyCode.Escape))
        {
            UnlockCursor();
        }
    }



    public void RestartGame()
    {
        SceneManager.LoadScene("Test");
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        PlayerMovement playerMove = GetComponent<PlayerMovement>();

        
        
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
       
    }


}
