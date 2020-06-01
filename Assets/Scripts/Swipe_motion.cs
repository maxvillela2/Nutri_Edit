using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Swipe_motion : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	
	

	private enum DraggedDirection
	{
		Up,
		Down,
		Right,
		Left
	}
	
	
	public Tool[] ITEM;
	public Tool[] ITEM2;
	public int Tool_Selector=0;
	public Image drag_space;
	public Shooter shooter;
	private float Dirr;
	private float Force = 0f;

	public Camera cam;
	Selecter selecter;
	void Start()
	{
		selecter = FindObjectOfType<Selecter>();
	}
	
 	public void OnBeginDrag(PointerEventData eventData)
	{
		
    }

	
	public void OnDrag(PointerEventData eventData)
	{
	
	}
	
	
	public void OnEndDrag(PointerEventData eventData)
	{
		if(selecter.getState())
		{
		Tool tool;	
		if(selecter.account)
		tool = Instantiate(ITEM[Tool_Selector],shooter.transform.position,Quaternion.identity);
		else
		tool = Instantiate(ITEM2[Tool_Selector],shooter.transform.position,Quaternion.identity);


		Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
		Rigidbody rg_tool = tool.GetComponent<Rigidbody>();

		Force = 500;
		float reducer = dragVectorDirection.y;

		float XF = Force*cam.transform.forward.x;
		float YF = Force*cam.transform.forward.y;
		float ZF = Force*cam.transform.forward.z*reducer;

		rg_tool.AddForce(new Vector3(XF,YF,ZF),ForceMode.Impulse);
		}

	}
	
	
	
	private DraggedDirection GetDragDirection(Vector3 dragVector)
	{
		float positiveX = Mathf.Abs(dragVector.x);
		float positiveY = Mathf.Abs(dragVector.y);

		DraggedDirection draggedDir;
		
		if (positiveX > positiveY)
		{
			draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
		}
		else
		{
			draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
		}
		
		Debug.Log(draggedDir);
		return draggedDir;
	}

}
