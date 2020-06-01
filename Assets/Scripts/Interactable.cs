using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    GameObject selected;

    string nombre;
    Ray ray;
    RaycastHit hit;
    int score;
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonUp(0)){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit)){
                selected = hit.collider.gameObject;
                nombre = selected.name;
                //GameObject.Find(nombre).GetComponent<Renderer>().material.SetColor("_Color",Color.blue);
                 if(gameObject.name == nombre){
                   
                  // GameObject.Find(nombre).
                    score +=50;    
                   Debug.Log(score);
                    Destroy(gameObject, 0.0f);
                    SpawnObject.spawnedQuantity--;
                 }
            }
            
        }*/

        
    }

        
    
}
