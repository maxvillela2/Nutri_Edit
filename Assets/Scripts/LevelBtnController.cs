using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelBtnController : MonoBehaviour
{
    //se consiguen de lo que esta guardado
    int currentLevel = 1;
    int currentEtapa = 1;
    int edad = 4;
    /////////////////////////////////////////
    private int i,j;
    // Start is called before the first frame update
    public enum GoalsStates {Desayuno,Comida,Cena,Metas,Badges,Sabias,Instrucciones};
    public GoalsStates current;
    public GoalsStates last;
    //Menu Canvas Objects
    public GameObject Desayuno1,Desayuno2, Comida1,Comida2,Comida3, Cena1,Cena2, MetaScr,BadgesScr,SabiasScr, Instrucc;
    public int frutaBadge, carneBadge, cerealBadge, lecheBadge, verduBadge, dulceBadge, recoBadge;
    public GameObject rec1,rec2,rec3;
    public GameObject SabiasQ0,SabiasQ1,SabiasQ2,SabiasQ3,SabiasQ4,SabiasQ5,SabiasQ6,SabiasQ7,SabiasQ8,SabiasQ9,SabiasQ10,SabiasQ11,SabiasQ12,SabiasQ13,SabiasQ14,SabiasQ15;


//current sabias que

    void Start()
    {

            current = GoalsStates.Metas;
       if(PlayerPrefs.GetInt("currentLevel") != 0 && PlayerPrefs.GetInt("currentEtapa") != 0 ){
            currentLevel = PlayerPrefs.GetInt("currentLevel");
            currentEtapa = PlayerPrefs.GetInt("currentEtapa");
            edad = int.Parse(PlayerPrefs.GetString("edad"));
        }
        else{
            PlayerPrefs.SetInt("currentLevel",1);
            PlayerPrefs.SetInt("currentEtapa",1);
            PlayerPrefs.Save();
        }

       // Debug.Log("Level: "+PlayerPrefs.GetInt("currentLevel")+" Etapa: "+PlayerPrefs.GetInt("currentEtapa")+" Edad: "+PlayerPrefs.GetString("edad"));
         
        /*Con esto al cargarse se ponen todos los botones desactivados */
        for(i=1; i<=7;i++){
            for(j=1; j<=3; j++){
                
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = false;
                
            }
        }

        /*Con esto, los botones de los niveles anteriores al actual se ponen activos */
        for(i=1; i<currentLevel;i++){
            for(j=1; j<=3; j++){
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = true;
                
            }
        }

        /*Con esto se toma en cuenta solo el nivel actual para activar las etapas anteriores y la actual */
        for(j=1; j<=currentEtapa; j++){
                GameObject.Find(currentLevel+""+j+"BTN").GetComponent<Button>().interactable = true;
               
            }
    
        frutaBadge = PlayerPrefs.GetInt("frutaBadge");
        carneBadge = PlayerPrefs.GetInt("carneBadge");
        cerealBadge = PlayerPrefs.GetInt("cerealBadge");
        lecheBadge = PlayerPrefs.GetInt("lecheBadge");
        verduBadge = PlayerPrefs.GetInt("verduraBadge");
        dulceBadge = PlayerPrefs.GetInt("dulceBadge");
        recoBadge = PlayerPrefs.GetInt("retosCant");
      

        AllInactive();
        SetAllInactiveBadges();
        SetUpBadges();
  
    }



    // Update is called once per frame
    void Update()
    {


      switch (current)
        {
            case GoalsStates.Desayuno:
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                SabiasScr.SetActive(false);
                Instrucc.SetActive(false);
                if(edad <= 9){
                    Desayuno1.SetActive(true);
                    Desayuno2.SetActive(false);
                }
                else{
                    Desayuno2.SetActive(true);
                    Desayuno1.SetActive(false);
                }
            break;

            case GoalsStates.Comida:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                SabiasScr.SetActive(false);
                Instrucc.SetActive(false);
                if(edad <=6){
                    Comida1.SetActive(true);
                    Comida2.SetActive(false);
                    Comida3.SetActive(false);
                }
                else if(edad >=7 && edad <=9){
                    Comida1.SetActive(false);
                    Comida2.SetActive(true);
                    Comida3.SetActive(false);
                }
                else if(edad >= 10){
                    Comida1.SetActive(false);
                    Comida2.SetActive(false);
                    Comida3.SetActive(true);
                }
            break;

            case GoalsStates.Cena:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                SabiasScr.SetActive(false);
                Instrucc.SetActive(false);
                if(edad <= 6){
                    Cena1.SetActive(true);
                    Cena2.SetActive(false);
                }
                else{
                    Cena1.SetActive(false);
                    Cena2.SetActive(true);
                }

            break;

            case GoalsStates.Metas:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                SabiasScr.SetActive(false);
                MetaScr.SetActive(true);
                BadgesScr.SetActive(false);
                Instrucc.SetActive(false);
            break;

            case GoalsStates.Badges:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                SabiasScr.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(true);
                Instrucc.SetActive(false);
            break;
            case GoalsStates.Sabias:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                SabiasScr.SetActive(true);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                Instrucc.SetActive(false);
            break;
                        
            case GoalsStates.Instrucciones:
                Desayuno1.SetActive(false);
                Desayuno2.SetActive(false);
                Comida1.SetActive(false);
                Comida2.SetActive(false);
                Comida3.SetActive(false);
                Cena1.SetActive(false);
                Cena2.SetActive(false);
                SabiasScr.SetActive(false);
                MetaScr.SetActive(false);
                BadgesScr.SetActive(false);
                Instrucc.SetActive(true);
            break;

        }
    }

    public void OnFirstEtapa()
    {
        Debug.Log("Desayuno");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Desayuno;
    }

    public void OnSecondEtapa()
    {
        Debug.Log("Comida");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Comida;
    }

    public void OnThirdEtapa()
    {
        Debug.Log("Cena");
        /*Esta parte deberia llevar al canvas correcto
        asi que deberia checar el valor edad para saber a cual ir */
        current = GoalsStates.Cena;
    }

    //si se preciona la TACHA, regresa a la pagina principal
    public void OnCancel()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Main");
    }

    //En los canvas de las metas, si se preciona la CASITA, regresa al canvas de los niveles
    public void OnHome()
    {
        Debug.Log("Home");
        current = GoalsStates.Metas;
    }
    //En el mapa si se presiona el trofeo lleva al canvas de medallas
    public void OnBadges()
    {
    
        Debug.Log("Badges");
        current = GoalsStates.Badges;
    }

        public void OnInstruction()
    {
        Debug.Log("Instrucctions");
        last = current;
        current = GoalsStates.Instrucciones;
    }

    public void OnCloseInstrucc(){
        Debug.Log("Back to meta");
        current = last;
    }

    public void OnStartGame(){
        Debug.Log("start");
        SceneManager.LoadScene("Game");

    }

    //En las metas, el signo de interrogacion, abre otros canvas (que no he hecho) con las instrucciones


    //En las metas, con el play llevaria a algun canvas random con "sabias que...?" (que no he hecho)
    public void OnPlay(){
        Debug.Log("meta to sabias que");
        //Desactivar la meta que este
        current = GoalsStates.Sabias;        
        SabiasScr.SetActive(true);
        AllInactive();
        int n = Random.Range(1, 17);
        GetOneSabiasQueCanvas(n);
    }

    public void AllInactive(){
        SabiasQ0.SetActive(false);
        SabiasQ1.SetActive(false);
        SabiasQ2.SetActive(false);
        SabiasQ3.SetActive(false);
        SabiasQ4.SetActive(false);
        SabiasQ5.SetActive(false);
        SabiasQ6.SetActive(false);
        SabiasQ7.SetActive(false);
        SabiasQ8.SetActive(false);
        SabiasQ9.SetActive(false);
        SabiasQ10.SetActive(false);
        SabiasQ11.SetActive(false);
        SabiasQ12.SetActive(false);
        SabiasQ13.SetActive(false);
        SabiasQ14.SetActive(false);
        SabiasQ15.SetActive(false);

    }

    public void GetOneSabiasQueCanvas(int index){
        switch(index){
            case 1:
                SabiasQ0.SetActive(true);
                break;
            case 2:
                SabiasQ1.SetActive(true);
                break;
            case 3:
                SabiasQ2.SetActive(true);
                break;
            case 4:
                SabiasQ3.SetActive(true);
                break;
            case 5:
                SabiasQ4.SetActive(true);
                break;
            case 6:
                SabiasQ5.SetActive(true);
                break;
            case 7:
                SabiasQ6.SetActive(true);
                break;
            case 8:
                SabiasQ7.SetActive(true);
                break;
            case 9:
                SabiasQ8.SetActive(true);
                break;
            case 10:
                SabiasQ9.SetActive(true);
                break;
            case 11:
                SabiasQ10.SetActive(true);
                break;
            case 12:
                SabiasQ11.SetActive(true);
                break;
            case 13:
                SabiasQ12.SetActive(true);
                break;
            case 14:
                SabiasQ13.SetActive(true);
                break;
            case 15:
                SabiasQ14.SetActive(true);
                break;
            case 16:
                SabiasQ15.SetActive(true);
                break;
            default:
            break;
        }
    }

    public void SetUpLevels(){
        current = GoalsStates.Metas;
        /*Con esto al cargarse se ponen todos los botones desactivados */
        for(i=1; i<=7;i++){
            for(j=1; j<=3; j++){
                Debug.Log(i+""+j+"BTN false");
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = false;
                Debug.Log(i+""+j+"BTN false");
            }
        }

        /*Con esto, los botones de los niveles anteriores al actual se ponen activos */
        for(i=1; i<currentLevel;i++){
            for(j=1; j<=3; j++){
                GameObject.Find(i+""+j+"BTN").GetComponent<Button>().interactable = true;
                Debug.Log(i+""+j+"BTN true");
            }
        }

        /*Con esto se toma en cuenta solo el nivel actual para activar las etapas anteriores y la actual */
        for(j=1; j<=currentEtapa; j++){
                GameObject.Find(currentLevel+""+j+"BTN").GetComponent<Button>().interactable = true;
                Debug.Log(i+""+j+"BTN true");
            }
    
    }     

    public void SetAllInactiveBadges(){
        for(i=0; i<=10; i++){
            if(GameObject.Find("fruta"+i) != null){
                GameObject.Find("fruta"+i).GetComponent<Button>().interactable = false;
            }
            if(GameObject.Find("carne"+i) != null){
                GameObject.Find("carne"+i).GetComponent<Button>().interactable = false;
            }
            if(GameObject.Find("cereal"+i) != null){
                GameObject.Find("cereal"+i).GetComponent<Button>().interactable = false;
            }
            if(GameObject.Find("leche"+i) != null){
                GameObject.Find("leche"+i).GetComponent<Button>().interactable = false;
            }
            if(GameObject.Find("verdu"+i) != null){
                GameObject.Find("verdu"+i).GetComponent<Button>().interactable = false;
            }
        }

        for(i=0; i<=15; i++){
            if(GameObject.Find("dulce"+i) != null){
                GameObject.Find("dulce"+i).GetComponent<Button>().interactable = false;
            }
        }

        GameObject.Find("Rec1").SetActive(false);
        GameObject.Find("Rec2").SetActive(false);
        GameObject.Find("Rec3").SetActive(false);

    }  

    public void SetUpBadges(){
        for(i=0; i<=frutaBadge; i++){
            if(GameObject.Find("fruta"+i) != null){
                GameObject.Find("fruta"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        for(i=0; i<=carneBadge; i++){
            if(GameObject.Find("carne"+i) != null){
                GameObject.Find("carne"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        for(i=0; i<=cerealBadge; i++){
           if(GameObject.Find("cereal"+i) != null){
                GameObject.Find("cereal"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        for(i=0; i<=lecheBadge; i++){
            if(GameObject.Find("leche"+i) != null){
                GameObject.Find("leche"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        for(i=0; i<=verduBadge; i++){
           if(GameObject.Find("verdu"+i) != null){
                GameObject.Find("verdu"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        for(i=0; i<=dulceBadge; i++){
            if(GameObject.Find("dulce"+i) != null){
                GameObject.Find("dulce"+i).GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
        }
        
        if(recoBadge == 1){
            rec1.SetActive(true);
            rec2.SetActive(false);
            rec3.SetActive(false);
        }
        if(recoBadge == 3){
            rec1.SetActive(true);
            rec2.SetActive(true);
            rec3.SetActive(false);
        }
        if(recoBadge == 7){
            rec1.SetActive(true);
            rec2.SetActive(true);
            rec3.SetActive(true);
        }
    }
}
