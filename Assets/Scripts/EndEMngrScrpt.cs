using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndEMngrScrpt : MonoBehaviour
{
    string gameOver;
    int score;
    int currentLevel,currentEtapa;
    public GameObject gameOverGood, gameOverExceso, gameOverHealth;
    public Text scoreTXT1,scoreTXT2,scoreTXT3;
    public Text numLevel;
    
    // Start is called before the first frame update
    void Start()
    {

        gameOver = PlayerPrefs.GetString("gameOver");
        score = PlayerPrefs.GetInt("score");
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        currentEtapa = PlayerPrefs.GetInt("currentEtapa");

        gameOverGood.SetActive(false);
        gameOverExceso.SetActive(false);
        gameOverHealth.SetActive(false);
        numLevel.text = currentLevel.ToString()+"-"+currentEtapa.ToString();

        
        scoreTXT1.text = score.ToString();
        scoreTXT2.text = score.ToString();
        scoreTXT3.text = score.ToString();


        if(Equals("Correcto",gameOver)) gameOverGood.SetActive(true);
        if(Equals("Exceso",gameOver)) gameOverExceso.SetActive(true);
        if(Equals("Salud",gameOver)) gameOverHealth.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void OnHome(){
        Debug.Log("End etapa to mapa");
        //Hasta este punto ya estan guardadas las cosas si se va a home va al mapa
        //En caso de que se haya completado correctamente, si se va a home, se habilita la siguiente etapa
        if(Equals("Correcto",gameOver)){
            PlayerPrefs.SetInt("currentEtapa",PlayerPrefs.GetInt("currentEtapa")+1);
            PlayerPrefs.Save();
        }
        //Despues se va al mapa de niveles
        if(PlayerPrefs.GetInt("currentEtapa") < 4 ) SceneManager.LoadScene("MapNGoals");
        //Para la etapa "4" que seria la finalizacion del juego, se abre un reto 
        else SceneManager.LoadScene("Reto");

    }

    public void OnRedo(){
        //Recargar un juego con las mismas caracteristicas  para rehacerlo
        Debug.Log("End etapa to game");
        SceneManager.LoadScene("Game");
    }

    public void OnNext(){
        PlayerPrefs.SetInt("currentEtapa",PlayerPrefs.GetInt("currentEtapa")+1);  //Ir a la siguiente etapa
        PlayerPrefs.Save();
        Debug.Log("End etapa to reto o game"); 
        //Para las etapas 1 2 3 , se abre un juego

        if(PlayerPrefs.GetInt("currentEtapa") < 4 ) SceneManager.LoadScene("MapNGoals");
        //Para la etapa "4" que seria la finalizacion del juego, se abre un reto 
        else SceneManager.LoadScene("Reto");
    }
}
