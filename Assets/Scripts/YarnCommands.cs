using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Events;

public class YarnCommands : MonoBehaviour
{
	[System.Serializable]
	public class YarnEvent{
		public string Name;
		public UnityEvent Event;
	}
	
	public List<YarnEvent> YarnEvents;
	
	[YarnCommand("event")]
	public void DoYarnEvent(string eventName){
		foreach(YarnEvent ye in YarnEvents){
			if(ye.Name == eventName){
				ye.Event.Invoke();
			}
		}
	}
	public GameObjectEvent OutputFoundGameObject;
	[YarnCommand("Goto")]
	public void MoveToGridSquare(string squareName){
		GameObject Target = GameObject.Find(squareName);
		Debug.Log(Target,Target);
		OutputFoundGameObject.Invoke(Target);
	}
}
