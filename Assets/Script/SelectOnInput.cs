using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
public EventSystem eventsystems;
public GameObject selectedobject;
private bool buttonSelected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxisRaw("Vertical")!=0 && buttonSelected==false)
		{
			eventsystems.SetSelectedGameObject(selectedobject);
			buttonSelected=true;
		}
	}
	public void Disable(){
		buttonSelected=false;
	}
}
