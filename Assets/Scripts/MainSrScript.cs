using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSrScript : MonoBehaviour
{
    public enum MainScrStates {Main,Badges,Profile,Info};
    public MainScrStates current;
    //Menu Canvas Objects
    public GameObject mainScr, badgesScr, profileScr,infoScr;
    public GameObject startBTN;
    public InputField name_Input,age_Input;

   
    void Start(){
        current = MainScrStates.Main;
        if(PlayerPrefs.GetString("edad") != "" && PlayerPrefs.GetString("nombre") != "")
            startBTN.GetComponent<Button>().interactable = true;
        else
            startBTN.GetComponent<Button>().interactable = false;

        
    }

    void Update(){

        // Checks current state
        switch (current)
        {
            case MainScrStates.Main:
                mainScr.SetActive(true);
                badgesScr.SetActive(false);
                profileScr.SetActive(false);
                infoScr.SetActive(false);
            break;

            case MainScrStates.Badges:
                mainScr.SetActive(false);
                badgesScr.SetActive(true);
                profileScr.SetActive(false);
                infoScr.SetActive(false);
            break;

            case MainScrStates.Profile:
                mainScr.SetActive(false);
                badgesScr.SetActive(false);
                profileScr.SetActive(true);
                infoScr.SetActive(false);
                
                name_Input = GameObject.Find("NAME_INPT").GetComponent<InputField>();
                age_Input = GameObject.Find("AGE_INPT").GetComponent<InputField>();

                
            break;

            case MainScrStates.Info:
                mainScr.SetActive(false);
                badgesScr.SetActive(false);
                profileScr.SetActive(false);
                infoScr.SetActive(true);
                break;

        }
    }
    // To start Game
    public void OnStartGame()
    {
        Debug.Log("Start Comic!");
        SceneManager.LoadScene("Comic");
    }
    //To view posible and collected badges
    public void OnBadges()
    {
        Debug.Log("Badges Canvas");
        current = MainScrStates.Badges;
    }
    //To view Game info
    public void OnInfo()
    {
        Debug.Log("Info Canvas");
        current = MainScrStates.Info;
    }
    //To create profile
    public void OnProfile()
    {
        Debug.Log("Profile Canvas");

        current = MainScrStates.Profile;
        if(PlayerPrefs.GetString("edad") != null && PlayerPrefs.GetString("nombre") != null)
            name_Input.text = PlayerPrefs.GetString("nombre");
            age_Input.text = PlayerPrefs.GetString("edad");
        
    }
    //To cancel badges viewing
    public void OnCancel()
    {
        Debug.Log("Back to Main");
        current = MainScrStates.Main;
    }
    //To go back to mainMenu
    public void OnBack()
    {
        Debug.Log("Back to Main");
        current = MainScrStates.Main;

    }
    //To save profile
    public void OnSave()
    {
     if(age_Input.text != "" && name_Input.text != ""){
            PlayerPrefs.SetString("edad",age_Input.text);
            PlayerPrefs.SetString("nombre",name_Input.text);
            PlayerPrefs.Save();
            Debug.Log("Edad is:" + PlayerPrefs.GetString("edad"));
            Debug.Log("Name is:" + PlayerPrefs.GetString("nombre"));
            startBTN.GetComponent<Button>().interactable = true;
        }
        else startBTN.GetComponent<Button>().interactable = false;


    Debug.Log("edad: "+ int.Parse(PlayerPrefs.GetString("edad")));

        current = MainScrStates.Main;
    }
       
        

    //Stop editing
    public void OnWriteEnd(){
        Debug.Log("END editing");

    }
    

}
