using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    // Start is called before the first frame update

	private bool gyroenabled;
	private Gyroscope gyro;
	private GameObject cameraContainer;
	private Quaternion rot;
	
	
	private void Start()
	{
		cameraContainer = new GameObject("Camera Container");
		cameraContainer.transform.position =  transform.position;
		transform.SetParent(cameraContainer.transform);
		
		gyroenabled = EnableGyro();
		
	}
	
	private void Update()
	{
		if(gyroenabled)
		{
			Quaternion q = gyro.attitude * rot;
			Debug.Log(q);
			transform.localRotation = q;
		}
	}
	
	private bool EnableGyro()
	{
		if(SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
			
			cameraContainer.transform.rotation = Quaternion.Euler(90f,90f,0f);
			rot = new Quaternion(0,0,1,0);
					
			Debug.Log("enabled");
			return true;
		}
		else
		{
			Debug.Log("Disabled");
			return false;
			
		}
		
	}
	
	
	
}
