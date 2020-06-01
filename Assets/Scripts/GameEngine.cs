using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{

   public Image light;
   public Sprite red,yellow,green;
   public float strtX,strtY,strtZ,timeInit,aux,auxY,auxZ,timeToDetect;
   public int count=0,up=0,doble=0,state=0,acum;
   public double randomTime;


   public bool startSemaforo;


   void Start(){
   		timeInit= Time.time;
   		strtX = (Input.acceleration.x*-10);
   		strtY =	(Input.acceleration.y*-10);
   		strtZ =	(Input.acceleration.z*-10);
   		randomTime = Random.Range(5,10);

		//startSemaforo = false;

		light.sprite = yellow;
   }

    void Update()
    {

		if(startSemaforo){

			if((Time.time - timeInit)>randomTime){
				if(state == 0){
					state=1;
					//Se pone el semaforo en rojo
					//estadoDeSemaforo.text = "Para";
					light.sprite = red;
					acum=count;
					timeToDetect = Time.time;
				}
				else if(state == 1){
					state=0;
					//Semaforo en verde
					light.sprite = green;
					randomTime = Random.Range(5,10);
				}
				
				timeInit=Time.time;
			}


			if(state==1 && acum<count){
				//termina el reto y perdio por moverse
				//estadoDeJugador.text = "Perdiste";

				light.sprite = yellow;

			}else{
				
				//estadoDeJugador.text = "Ganando";

			}

			if((Time.time-timeToDetect)>1.5){
				aux = (Input.acceleration.y*-10);
				auxY = (Input.acceleration.x*-10);
				auxZ = 	(Input.acceleration.z*-10);
				if(aux>15 || auxY>2 || auxZ > 2)
					up=1;

				if(up==1 && (aux<5 || auxY<-2 || auxZ<-2)){
					up=0;
					count++;
				}
			}


			if(count == 500){
				//En esta parte ganaria y saldria de la escena
				//estadoFinal.text = "You win lml";
				startSemaforo = false;
			}
		}
    }

	public bool SemaforoState(){
        return startSemaforo;
    }
}
