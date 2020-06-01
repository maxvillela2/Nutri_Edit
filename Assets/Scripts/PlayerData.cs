using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   
   public string name;
   public int age;

   public PlayerData(MainSrScript player){
   		name = player.name_Input.text;
   		age = int.Parse(player.age_Input.text);
   }

}
