using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineGame : MonoBehaviour
{
   public Text coordinates,coordinates2;

   public float aux,timeIni;


   public int countSaltos=0,up=0,doble=0, maxNum;

   public bool startSalto, finished;

   void Start(){
   		timeIni = Time.time;
		//startSalto = true;
		//Set max num
		maxNum = Random.Range(9, 20);
		coordinates.text = maxNum.ToString();
		coordinates2.text = maxNum.ToString();
		countSaltos = maxNum;
   }

    void Update()
    {
		if(startSalto){

			aux = (Input.acceleration.y*-10);

			if(aux>15 && (Time.time-timeIni)>.5)
				up=1;

			if(up==1 && aux<5 ){
				up=0;
				timeIni = Time.time;
				countSaltos--;
			}

			coordinates.text = countSaltos.ToString();
			coordinates2.text = countSaltos.ToString();
			if(countSaltos == 0){
				//En esta parte ya te felicita por los saltos y termina el juego
				startSalto = false;
			}
			
 	   }
	}

	public bool SaltosState(){
        return startSalto;
    }
}
