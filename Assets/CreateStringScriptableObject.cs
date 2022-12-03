using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateStringScriptableObject : MonoBehaviour
{
	public string ScriptableObjectSavePath = "Assets/ScriptableObjects/Grids/";
	public OutputStringEvent OutputStringEvent;
	
	public void InputString(string input){
		if(OutputStringEvent.StringReference.Variable==null){
			StringVar stringVar = StringVariable(input,ScriptableObjectSavePath+input+".asset");
			OutputStringEvent.StringReference.UseConstant = false;
			OutputStringEvent.StringReference.Variable = stringVar;
		}
	}
	
	public StringVar StringVariable(string _val,string path){
		StringVar output = ScriptableObject.CreateInstance<StringVar>();
		output.Value = _val;
		AssetDatabase.CreateAsset(output,path);
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = this;
		return output;
	}
}
