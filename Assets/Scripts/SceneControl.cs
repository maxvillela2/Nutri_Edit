using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    Sprite[] clock;
    Sprite[] window;
    int num=0;
    float fillAmount=0;
    public GameObject clockImg;
    public GameObject windowImg;
    public GameObject loadingBar;
    public GameObject levelCompleteCanvas;
    public GameObject animationCanvas;
    public GameObject btn;
    public GameObject btn2;
    float waitTime;
   bool showAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
      window = Resources.LoadAll<Sprite>("Animation/Window");
      clock = Resources.LoadAll<Sprite>("Animation/Clock");
      showAnimation = false;
      btn.GetComponent<Button>().interactable = false;
      btn2.GetComponent<Button>().interactable = false;
      levelCompleteCanvas.SetActive(true);
      animationCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(num < 73 && showAnimation){
             waitTime += Time.deltaTime;
            if(waitTime >= 0.2f && num<73){
                
                clockImg.GetComponent<Image>().sprite = clock[num];
                windowImg.GetComponent<Image>().sprite = window[num/6];
                loadingBar.GetComponent<Image>().fillAmount = fillAmount / 72;
                
                waitTime = 0;
                num++;
                fillAmount++;
            }
        }
        else{
            showAnimation = false;
             
        }
        btn.GetComponent<Button>().interactable = !showAnimation;
        btn2.GetComponent<Button>().interactable = !showAnimation;
    }

    public void OnNextStep(){
      levelCompleteCanvas.SetActive(false);
      animationCanvas.SetActive(true);
      showAnimation = true;
    }

    public void OnNextLevel(){
        //Cuando se presione siguiente nivel, se debe actualizar currentLevel y llevarlo al mapa de niveles
        
        PlayerPrefs.SetInt("currentLevel",PlayerPrefs.GetInt("currentLevel")+1);
        PlayerPrefs.SetInt("currentEtapa",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MapNGoals");
    }
}
