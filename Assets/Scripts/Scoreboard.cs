using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    float G_Carne;
	float G_Lacteos;
	float G_Verduras;
	float G_Frutas;
	float G_Cereales;
	float G_candy;
    public float Carne=0;
    public float Lacteos=0;
    public float Verduras=0;
    public float Cereales=0;
    public float Frutas=0;
	public float total;

	public float M_Carne;
	public float M_Lacteos;
	public float M_Verduras;
	public float M_Cereales;
	public float M_Frutas;
	
	//public Text L_Score;
	public Image _Carne;
	public Image _Lacteos;
	public Image _Verduras;
	public Image _Cereales;
	public Image _Frutas;
	//banderas de metas completas
	public bool carne_f;
	public bool lacteos_f;
	public bool verduras_f;
	public bool cereales_f;
	public bool frutas_f;

	public int eatenCarne=0;
    public int eatenLacteos=0;
    public int eatenVerduras=0;
    public int eatenCereales=0;
    public int eatenFrutas=0;
	public int destroyedDulces=0;
	public int excesos=0;
	public int Score=0;
	public int health=0;
	public int edad;

	Selecter SL;
	
    void Start()
    {
		SL = FindObjectOfType<Selecter>();
		clear_sprites();
		Debug.Log("Start");
		total = 0;
		health = 50;
		
		carne_f=false;
		lacteos_f=false;
		verduras_f=false;
		cereales_f=false;
		frutas_f=false;

		eatenCarne =0;
    	eatenLacteos=0;
    	eatenVerduras=0;
    	eatenCereales=0;
    	eatenFrutas=0;
		destroyedDulces=0;
		excesos=0;

		try{
			edad = int.Parse(PlayerPrefs.GetString("edad"));
		}catch{
			edad = 1;
		}
		
		SetPorcionesMeta();
    }


    // Update is called once per frame
    void Update()
    {
        
		
		
    }
	
	public void Update_Sprites()
	{
		clear_sprites();
		_Carne.fillAmount += Carne / M_Carne;
		_Cereales.fillAmount += Cereales / M_Cereales;
		_Verduras.fillAmount += Verduras / M_Verduras;
		_Frutas.fillAmount += Frutas / M_Frutas;
		_Lacteos.fillAmount += Lacteos / M_Lacteos;
		
		
	}
	
	void clear_sprites()
	{
		
		_Carne.fillAmount -= 1;
		_Cereales.fillAmount -= 1;
		_Verduras.fillAmount -= 1;
		_Frutas.fillAmount -= 1;
		_Lacteos.fillAmount -= 1;

	}
	//  GET Values
	public int score_value(){return this.Score;}
	public int health_value(){return this.health;}
	public int eatenCarne_value(){return this.eatenCarne;}
	public int eatenLacteos_value(){return this.eatenLacteos;}
	public int eatenVerduras_value(){return this.eatenVerduras;}
	public int eatenCereales_value(){return this.eatenCereales;}
	public int eatenFrutas_value(){return this.eatenFrutas;}
	public int destroyedDulces_value(){return this.destroyedDulces;}
	public int excesos_value(){return this.excesos;}

	public void SetPorcionesMeta(){
		int currentStage;
		try{
			currentStage= PlayerPrefs.GetInt("currentEtapa");
		}catch{
			currentStage = 1;
		}
		
		if(currentStage== 1){
			if(edad <= 9){
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=40;
				M_Carne=20;
				M_Cereales=20;
			}else{
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=40;
				M_Carne=20;
				M_Cereales=40;
			}
		}
		if(currentStage == 2){
			if(edad <= 6){
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=20;
				M_Carne=40;
				M_Cereales=40;
			}else if(edad >=7 && edad <=9){
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=20;
				M_Carne=40;
				M_Cereales=60;
			}else if(edad >=10){
				M_Lacteos=20;
				M_Verduras=40;
				M_Frutas=20;
				M_Carne=40;
				M_Cereales=60;
			}
		}
		if(currentStage == 3){
			if(edad <= 6){
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=20;
				M_Carne=20;
				M_Cereales=20;
			}else{
				M_Lacteos=20;
				M_Verduras=20;
				M_Frutas=20;
				M_Carne=40;
				M_Cereales=40;
			}
		}
	}

		
	public bool Check_carne()
	{
		carne_f = (Carne >= M_Carne ? true : false);
		return carne_f;
	}
	public bool Check_verduras()
	{
		verduras_f = (Verduras >= M_Verduras ? true : false);
		return verduras_f;
	}
	public bool Check_fruta()
	{
		frutas_f = (Frutas >= M_Frutas ? true : false);
		return frutas_f;
	}
	public bool Check_cereales()
	{
		cereales_f = (Cereales >= M_Cereales ? true : false);
		return cereales_f;
	}
	public bool Check_lacteos()
	{
		lacteos_f = (Lacteos >= M_Lacteos ? true : false);
		return lacteos_f;
	}


	public void update_score(G_Foes c)
	{

		//Dependiendo del tipo del objeto, actualizar HEALTH / SCORE / METAS

		if(SL.GetOption() == 2){
			//si come un alimento de origen animal
			if(c.Animal>0)
			{
				
				this.Carne += c.Animal;
				//si la meta fue completada o no
				if(carne_f){
					health -=8;
					Score -=10;
					excesos++;
				}
				else{
					health +=4;
					Score +=80;
					eatenCarne++;
				}
			}
			//si come verduras		
			if(c.Verduras>0)
			{
				
				this.Verduras += c.Verduras;
				if(verduras_f){
					health -=8;
					Score -=10;
					excesos++;
				}
				else{
					health +=4;
					Score +=80;
					eatenVerduras++;
				}
			}
			//si come frutas	
			if(c.Frutas>0)
			{

				this.Frutas += c.Frutas;
				if(frutas_f){
					health -=8;
					Score -=10;
					excesos++;
				}
				else{
					health +=4;
					Score +=80;
					eatenFrutas++;
				}
			}		
			//si come cereales	
			if(c.Cereales>0)
			{
				
				this.Cereales += c.Cereales;
				if(cereales_f){
					health -=8;
					Score -=10;
					excesos++;
				}
				else{
					health +=4;
					Score +=80;
					eatenCereales++;
				}
			}
			//si come lacteos	
			if(c.lacteos > 0)
			{
				
				this.Lacteos += c.lacteos;
				if(lacteos_f){
					health -=8;
					Score -=10;
					excesos++;
				}
				else{
					health +=4;
					Score +=80;
					eatenLacteos++;
				}
			}
			//si come dulces	
			if(c.Dulces > 0)
			{
					health -=8;
					Score -=20;
			}
		}


		if(SL.GetOption() == 5){
			//si destruye un alimento de origen animal
			if(c.Animal>0)
			{
				//si la meta fue completada o no
				if(carne_f){
					health +=2;
					Score +=80;
				}
				else{
					Score +=10;
				}
			}
			//si destruye verduras		
			if(c.Verduras>0)
			{
				if(verduras_f){
					health +=2;
					Score +=80;
				}
				else{
					Score +=10;
				}
			}
			//si destruye frutas	
			if(c.Frutas>0)
			{
				if(frutas_f){
					health +=2;
					Score +=80;
				}
				else{
					Score +=10;
				}
			}		
			//si destruye cereales	
			if(c.Cereales>0)
			{
				if(cereales_f){
					health +=2;
					Score +=80;
				}
				else{
					Score +=10;
				}
			}
			//si destruye lacteos	
			if(c.lacteos > 0)
			{
				if(lacteos_f){
					health +=2;
					Score +=80;
				}
				else{
					Score +=10;
				}
			}
			//si destruye dulces	
			if(c.Dulces > 0)
			{
					destroyedDulces++;
					health +=10;
					Score +=100;
			}
		}

		Check_carne();
		Check_cereales();
		Check_fruta();
		Check_lacteos();
		Check_verduras();

		/*if(c.Animal>0)
		{
			if(carne_f)
				health -=15;
			else
				health +=8;
		}
				
		if(c.Verduras>0)
		{
			if(verduras_f)
				health -=15;
			else
				health +=8;
		}

		if(c.Frutas>0)
		{
			if(frutas_f)
				health -=15;
			else
				health +=8;
		}		
		
		if(c.Cereales>0)
		{
			if(cereales_f)
				health -=15;
			else
				health +=8;
		}
		
		if(c.lacteos > 0)
		{
			if(lacteos_f)
				health -=15;
			else
				health +=8;
		}

		if(isCandyDestroyed(c))
		{

			G_candy += 1;

		}


		if(SL.account){
		this.Carne += c.Animal*(1/M_Carne);
		this.Lacteos += c.lacteos*(1/M_Lacteos);
		this.Verduras += c.Verduras*(1/M_Verduras);
		this.Cereales += c.Cereales*(1/M_Cereales);
		this.Frutas += c.Frutas*(1/M_Frutas);
		this.Score += c.Points;

		total += 0.7f; 
		}
	
		Check_carne();
		Check_cereales();
		Check_fruta();
		Check_lacteos();
		Check_verduras();
*/
	}


	void OnDisable()
	{
		
	G_Carne += Carne;
	G_Lacteos += Lacteos;
	G_Verduras += Verduras;
	G_Frutas += Frutas;
	G_Cereales += Cereales;

	}

	bool isCandyDestroyed(G_Foes g)
	{
		if(g.Animal == 0 && g.Cereales == 0 && g.Frutas == 0 && g.Verduras == 0 && g.lacteos == 0)
		{
			if(SL.account)
			{
				return true;
			}
			else
			return false;
		}
		else
		return false; 
	}

	void Awake()
	{
	/* 	
	G_Carne ;
	G_Lacteos ;
	G_Verduras ;
	G_Frutas ;
	G_Cereales ;
		Aqui deben cargar los valores guardados DANNY
	*/

	}
}
