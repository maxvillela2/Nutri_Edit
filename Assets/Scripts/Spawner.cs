using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
  //	public Aux_Foe List_prefabs;
	
	//public List<G_Foes> Foe_List = new List<G_Foes>(); 

	private int ct_frame;
	private int ct_sec;
	public int ct_enemies;

	public int spVerduQuantity;
	public int spFrutaQuantity;
	public int spCerealQuantity;
	public int spCarneQuantity;
	public int spLecheQuantity;
	public int spDulceQuantity;

	public int maxSpawned = 4;
	float xRand,yRand,zRand;
	//Crear lista 
 	private string[] lista_verdura = new string[] {"Aguacate","Berenjena","Brocoli","Calabacita","Cebolla","Guisante","Hongo","Maiz","Nopal","PepinoReb","Pimiento","TomateReb","Zanahoria"};
	private string[] lista_fruta = new string[] {"Banana","ManzanaM","NaranajaM","NaranjaC","Cereza","Frambuesa","Fresa","Kiwi","Mango","Papaya","Pina","Sandia","Uva"};
	private string[] lista_cereal = new string[] {"Arroz","Bolillo","Hotcakes","Pan","Tortilla"};
	private string[] lista_carne = new string[] {"Eggs","Carne","BoiledEgg","Pollo"};
	private string[] lista_leche = new string[] {"Leche","Queso","Yogurt"};
	private string[] lista_dulce = new string[] {"Paleta","Nieve","Dulce","Pastel"};

	/*private string[] lista_comida = new string[] {"Banana","ManzanaM","NaranajaM","NaranjaC","Paleta","Eggs","Leche","Nieve","Carne"
													,"Pepino","Pollo","Queso","Sandia","Pastel","Dulce","BoiledEgg","Cereza","Fresa"
													,"Yogurt","Tortillas","Pan","Arroz","Bolillo","Hotcakes"};*/


	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		if(maxSpawned > spVerduQuantity){
           Spawn(1);
        }

		if(maxSpawned > spFrutaQuantity){
           Spawn(2);
        }

		if(maxSpawned > spCerealQuantity){
           Spawn(3);
        }

		if(maxSpawned > spCarneQuantity){
           Spawn(4);
        }

		if(maxSpawned > spLecheQuantity){
           Spawn(5);
        }

		if(maxSpawned > spDulceQuantity){
           Spawn(6);
        }




		/*ct_frame++;
		if(ct_frame == 30)
		{
		
			ct_frame = 0;
			ct_sec++;
			
			if(ct_sec == 1)
			{
			
				ct_sec = 0;
				if(ct_enemies <= 30)
					Spawn();
			
			}
		
		}	*/
			
	}
	
	public void remove_foe(G_Foes g)
	{	

		if(g.Verduras>0) spVerduQuantity--;
		if(g.Frutas>0) spFrutaQuantity--;
		if(g.Animal>0) spCarneQuantity--;
		if(g.Cereales>0) spCerealQuantity--;
		if(g.Dulces>0) spDulceQuantity--;
		if(g.lacteos>0) spLecheQuantity--;


	}


//para mantener contante la cantidad de objetos que aparecen y que haya oportunidad de todo


	public void Spawn(int type){

		if(type == 1){
			G_Foes food = Resources.Load(lista_verdura[Random.Range(0,lista_verdura.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spVerduQuantity++;
		}

		if(type == 2){
			G_Foes food = Resources.Load(lista_fruta[Random.Range(0,lista_fruta.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spFrutaQuantity++;
		}

		if(type == 3){
			G_Foes food = Resources.Load(lista_cereal[Random.Range(0,lista_cereal.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spCerealQuantity++;
		}

		if(type == 4){
			G_Foes food = Resources.Load(lista_carne[Random.Range(0,lista_carne.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spCarneQuantity++;
		}

		if(type == 5){
			G_Foes food = Resources.Load(lista_leche[Random.Range(0,lista_leche.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spLecheQuantity++;
		}

		if(type == 6){
			G_Foes food = Resources.Load(lista_dulce[Random.Range(0,lista_dulce.Length)],typeof(G_Foes))as G_Foes;
			Debug.Log(food);
			Instantiate(food,Spawn_position(),Quaternion.identity);
			spDulceQuantity++;
		}

	}



	/*public void Spawn()
	{

		G_Foes food = Resources.Load(lista_comida[Random.Range(0,lista_comida.Length)],typeof(G_Foes))as G_Foes;
		Instantiate(food,Spawn_position(),Quaternion.identity);
		//Debug.Log(food.name);
		//Foe_List.Add(food);
		ct_enemies++;
	}*/




	Vector3 Spawn_position(){
		
		bool validNum = false;

		while(!validNum){
            xRand = Random.Range(-6.0f,15.0f);
            zRand = Random.Range(-6.0f,15.0f);
            /*Verificar que se encuentren en un rango circular (siempre a >5 unidades de la camara) 
                con x^2 + y^2 = r^2 ecuacion de un circulo en el plano, do9nde r = 3*/
            if((xRand*xRand + zRand*zRand) > 25.0f && (xRand*xRand + zRand*zRand) <327.0f)
                validNum = true;
        }


		yRand = Random.Range(-5.0f,6.0f);

		return new Vector3(xRand,yRand,zRand);
	}


/*
	Vector3 Spawn_position()
		{
			int SPx = 0;
			int SPy = 0;
			int SPz = 0;
			int Dirx = 0;
			int Dirz = 0;
			int Diry = 0;



			SPx = Random.Range(1,4);
			SPz = Random.Range(1,4);
			SPy = Random.Range(1,4);

			while(Dirx == 0)
			{
				Dirx = Random.Range(-1,2);
			}
			while(Dirz == 0)
			{
				Dirz = Random.Range(-1,2);
			}
			while(Diry == 0)
			{
				Diry = Random.Range(-1,2);
			}
			if(Dirx == -1)
			{
				//Debug.Log("Izquierda");
			}
			else
			{
				//Debug.Log("Derecha");
			}
			if(Dirz == -1)
			{
				//Debug.Log("Atras");
			}
			else
			{
				//Debug.Log("Enfrente");
			}



			return new Vector3(Dirx*SPx*7,Diry*SPy*7,Dirz*SPz*7); //Direccion * Distancia * 

		} */
	
}
	
	

