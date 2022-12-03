using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
	public int RowCount;
	public int ColumnCount;
	public float SquareDistance;
	
	public OutputStringEvent GridPrefab;
	
	public void Generate(){
		Vector3 position = transform.position;
		for (int x = 0; x < RowCount; x++) {
			for (int  y= 0; y < ColumnCount; y++) {
				position = transform.position + new Vector3(x,-y,0);
				OutputStringEvent square = Instantiate(GridPrefab,position,Quaternion.identity,transform);
				
				square.SetValue(x  + "-" + y);
				square.OutputString();
			}
			//position += new Vector3(x,0,0);
		}
	}
}
