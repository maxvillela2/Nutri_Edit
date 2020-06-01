using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetoScrpt : MonoBehaviour
{

    public enum retoStates{ Sentadillas, Saltos, Semaforo,Reco};
    public retoStates current;
    
    public Sprite bronce,plata,oro;
    public Image level;
    public int cant;

    public GameObject saltoCanvas, sentaCanvas, semaCanvas, reco,winR;

    public Text nombre;
    public string name;

    public GameEngine GE;
    public EngineGame EG;
   
    // Start is called before the first frame update
    void Start()
    {
       GE = FindObjectOfType<GameEngine>();
       EG = FindObjectOfType<EngineGame>();
       winR.SetActive(false);
       //Reto Random
       nombre.text = name;
       

       int canvas = Random.Range(0,4); 
       if(canvas==1){current = retoStates.Semaforo; GE.startSemaforo = true;}
       else if(canvas==2){current = retoStates.Saltos; EG.startSalto = true;}
       else if(canvas==3){current = retoStates.Sentadillas; EG.startSalto = true;}
       else {current = retoStates.Saltos; EG.startSalto = true;}
    }

    // Update is called once per frame
    void Update()
    {
        switch (current)
        {
            case retoStates.Sentadillas:
                saltoCanvas.SetActive(false);
                sentaCanvas.SetActive(true);
                semaCanvas.SetActive(false);
                reco.SetActive(false);
                if(EG.SaltosState()){ //if playing
                    winR.SetActive(false);
                }else{
                    winR.SetActive(true);    
                }
            break;
            case retoStates.Saltos:
                saltoCanvas.SetActive(true);
                sentaCanvas.SetActive(false);
                semaCanvas.SetActive(false);
                reco.SetActive(false);
                if(EG.SaltosState()){ //if playing
                    winR.SetActive(false);
                }else{
                    winR.SetActive(true);
                }
            break;
            case retoStates.Semaforo:
                saltoCanvas.SetActive(false);
                sentaCanvas.SetActive(false);
                semaCanvas.SetActive(true);
                reco.SetActive(false);
                if(GE.SemaforoState()){ //if playing
                    winR.SetActive(false);
                }else{
                    winR.SetActive(true);
                }
            break;
            case retoStates.Reco:
                saltoCanvas.SetActive(false);
                sentaCanvas.SetActive(false);
                semaCanvas.SetActive(false);
                reco.SetActive(true);
                winR.SetActive(false);
                SetLevelImg();
            break;
        }
    }

    public void OnSkip(){

        SceneManager.LoadScene("ENDNivel");
    }

    public void OnFinish(){
        if(!GE.SemaforoState() || !EG.SaltosState()){
            Debug.Log("Save score if finished");
            PlayerPrefs.SetInt("totalScore",  200 + PlayerPrefs.GetInt("totalScore"));
            PlayerPrefs.SetInt("retosCant", PlayerPrefs.GetInt("retosCant") + 1 ); 
            PlayerPrefs.Save();
        }
        current = retoStates.Reco;

    }

    public void SetLevelImg(){
        cant = PlayerPrefs.GetInt("retosCant");
        if(cant == 1) level.sprite = bronce;
        if(cant == 3) level.sprite = plata;
        if(cant == 7) level.sprite = oro;
    }


}
