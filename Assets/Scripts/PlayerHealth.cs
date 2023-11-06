using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

   public Text healthText;
    public int playerHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;


    

    public static PlayerHealth instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
      




        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.text = playerHealth.ToString();
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        if(playerHealth <= 0)
        {
            deadScreen.SetActive(true);
            PlayerMovement.instance.hasDied = true;
            StartCoroutine(Mainmenu());

            

           

            
        }
    }

    IEnumerator Mainmenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }

}
