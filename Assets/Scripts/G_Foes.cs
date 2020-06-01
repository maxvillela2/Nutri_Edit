using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Foes : Foes
{
    
    public float Verduras;
    public float Frutas;
    public float Animal;
    public float Cereales;
    public float Dulces;
    public float lacteos;
	
	Transform GO;
	public G_Foes(string name, int points){
		
		this.Name = name;
		this.Points = points;
		
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        GO = this.GetComponent<Transform>();
	
    }

    // Update is called once per frame

	
    private void Update()
	{
		movement_degree();
    }

    void movement_degree()
    {
            
        float yRotation = GO.rotation.eulerAngles.y;

        yRotation += 1.0f;
        GO.eulerAngles = new Vector3(GO.rotation.eulerAngles.x, yRotation, GO.eulerAngles.z);
    
 
    }
	

	
	

	
	
}
