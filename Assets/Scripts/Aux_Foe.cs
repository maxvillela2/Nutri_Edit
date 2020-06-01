using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aux_Foe : MonoBehaviour
{
    
	public G_Foes Apple;
	public G_Foes Meat;
	public G_Foes Candy;
	public G_Foes Orange;
	public G_Foes MOrange;
	public List<G_Foes> List_prefab;
	
	
	
	// Start is called before the first frame update
    void Start()
    {
       List_prefab.Add(Apple);
	   List_prefab.Add(Meat);
	   List_prefab.Add(Candy);
	   List_prefab.Add(Orange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
