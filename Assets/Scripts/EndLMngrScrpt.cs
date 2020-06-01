using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLMngrScrpt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text numeroNivel;
    public Text totalScore;
    int i;
    int healthLevel;
    bool carneB_f, lecheB_f, verduB_f, frutaB_f, cerealB_f, dulceB_f;
    int actualValueCarne, actualValueVerdu, actualValueCereal, actualValueFruta, actualValueLeche, actualDulce, actualHealth;
    public GameObject toClone;
    GameObject item;
    public Transform container;
    Sprite spriteAux;

    void Start()
    {
        numeroNivel.text = PlayerPrefs.GetInt("currentLevel").ToString();
        totalScore.text = PlayerPrefs.GetInt("totalScore").ToString();
        healthLevel = 0;
        carneB_f=false;
        lecheB_f=false;
        verduB_f=false;
        frutaB_f=false;
        cerealB_f=false;
        dulceB_f=false;

        actualValueCarne = PlayerPrefs.GetInt("carneBadge");
        actualValueVerdu = PlayerPrefs.GetInt("verduraBadge");
        actualValueCereal = PlayerPrefs.GetInt("cerealBadge");
        actualValueFruta = PlayerPrefs.GetInt("frutaBadge");
        actualValueLeche = PlayerPrefs.GetInt("lecheBadge");
        actualDulce = PlayerPrefs.GetInt("dulceBadge");
        actualHealth = PlayerPrefs.GetInt("totalHealth");

        ValidateBadges();
        SetObtainedBadges();

     }

    // Update is called once per frame
    void Update()
    {

    }

//Si hubo un cambio, considerarlo par aque aparezca la medalla
    void ValidateBadges(){
        //Las medallas por alimentos consumidos por categoria, se dan cada 5 10 15 20 25 30 35 40 45 50, acumuladas en TODAS las etapas
//Si la cantidad acumulada es mayor o igual que la variable de medallas de esa categoria + 1, entonces la variable de medallas se incrementa para obtener la siguiente medalla
// solo existen 10 medallas de cada una, por lo que se debe limitar a ese valor
        if( (PlayerPrefs.GetInt("totalCarne")/5) >= (actualValueCarne + 1) ) {
            //Badge ++
            if(actualValueCarne < 10 ) {PlayerPrefs.SetInt("carneBadge", actualValueCarne + 1 ); carneB_f=true;} 
        }

        if( (PlayerPrefs.GetInt("totalLacteos")/5) >= (actualValueLeche + 1) ) {
            //Badge ++
            if(actualValueLeche < 10 ) {PlayerPrefs.SetInt("lecheBadge",actualValueLeche + 1 ); lecheB_f=true;}
        }

        if( (PlayerPrefs.GetInt("totalVerduras")/5) >= (actualValueVerdu + 1) ) {
            //Badge ++
            if(actualValueVerdu < 10 ) {PlayerPrefs.SetInt("verduraBadge", actualValueVerdu + 1 ); verduB_f=true;}
        }

        if( (PlayerPrefs.GetInt("totalCereales")/5) >= (actualValueCereal + 1) ) {
            //Badge ++
            if(actualValueCereal < 10 ) {PlayerPrefs.SetInt("cerealBadge", actualValueCereal + 1 ); cerealB_f=true;}
        }

        if( (PlayerPrefs.GetInt("totalFrutas")/5) >= (actualValueFruta + 1) ) {
            //Badge ++
            if(actualValueFruta < 10 ) {PlayerPrefs.SetInt("frutaBadge", actualValueFruta + 1 ); frutaB_f=true;}
        }

        if( (PlayerPrefs.GetInt("totalDulces")/5) >= (actualDulce + 1) ) {
            //Badge ++
            if(actualDulce < 17 ) {PlayerPrefs.SetInt("dulceBadge", actualDulce + 1 ); dulceB_f=true;}
        }

        if( (actualHealth/3) >= 56 && (actualHealth/3) <=70) healthLevel = 1;
        if( (actualHealth/3) >= 71 && (actualHealth/3) <=85) healthLevel = 2;
        if( (actualHealth/3) >= 86) healthLevel = 3;

        PlayerPrefs.SetInt("totalHealth",0);

        PlayerPrefs.Save();
    }


    //*****************************************************************************************************************************************************************
    //Set obtained badges

    void SetObtainedBadges(){
        
        if(healthLevel > 0){
            instantiateBadge();
            // Emojis
            if(healthLevel == 1){ SetNewText("Buena Salud"); SetNewImage("health1");}
            if(healthLevel == 2){ SetNewText("Excelente Salud"); SetNewImage("health2");}
            if(healthLevel == 3){ SetNewText("Salud Sobresaliente"); SetNewImage("health3");}
            healthLevel = 0;    
        }

        if(carneB_f){
            carneB_f=false;
            instantiateBadge();
            SetNewText("Consumir alimentos de origen animal Nivel "+PlayerPrefs.GetInt("carneBadge").ToString());
            SetNewImage("carne"+PlayerPrefs.GetInt("carneBadge").ToString());
        }
        if(lecheB_f){
            lecheB_f=false;
            instantiateBadge();
            SetNewText("Consumir lacteos Nivel "+PlayerPrefs.GetInt("lecheBadge").ToString());
            SetNewImage("leche"+PlayerPrefs.GetInt("lecheBadge").ToString());
        }
        if(verduB_f){
            verduB_f=false;
            instantiateBadge();
            SetNewText("Consumir verduras Nivel "+PlayerPrefs.GetInt("verduraBadge").ToString());
            SetNewImage("verdu"+PlayerPrefs.GetInt("verduraBadge").ToString());
        }
        if(cerealB_f){
            cerealB_f=false;
            instantiateBadge();
            SetNewText("Consumir cereales Nivel "+PlayerPrefs.GetInt("cerealBadge").ToString());
            SetNewImage("cereal"+PlayerPrefs.GetInt("cerealBadge").ToString());
        }
        if(frutaB_f){
            frutaB_f=false;
            instantiateBadge();
            SetNewText("Consumir frutas Nivel "+PlayerPrefs.GetInt("frutaBadge").ToString());
            SetNewImage("fruta"+PlayerPrefs.GetInt("frutaBadge").ToString());
        }
        if(dulceB_f){
            dulceB_f=false;
            instantiateBadge();
            SetNewText("Destruir dulces Nivel "+PlayerPrefs.GetInt("dulceBadge").ToString());
            SetNewImage("dulce"+PlayerPrefs.GetInt("dulceBadge").ToString());
        }
       


    }
    void instantiateBadge(){
        item = Instantiate (toClone, transform.position, transform.rotation);
        item.transform.SetParent(container.transform,false);
    }

    void SetNewText(string newName){
        Text text = item.GetComponent<Transform>().Find("Text").GetComponent<Text>();
        text.text = newName;
    }

    void SetNewImage(string newImgName){
        Sprite newImg = Resources.Load("Sprites/"+newImgName ,typeof(Sprite)) as Sprite;
        Image img = item.GetComponent<Transform>().Find("Image").GetComponent<Image>();
        img.sprite = newImg;
    }
}
