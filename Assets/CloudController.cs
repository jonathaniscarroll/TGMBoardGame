using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
	public List<Transform> Clouds;
	public float StartX;
	public float EndX;
	[MinMaxSlider(0,5)]
	public Vector2 RangeY;
	[MinMaxSlider(0,5)]
	public Vector2 RangeZ;
	public float Speed;
	int current;
	
	void Start(){
		foreach(Transform cloud in Clouds){
			Reset(cloud);
		}
	}
	void Update(){
		if(current<Clouds.Count-1){
			current++;
		} else {
			current = 0;
		}
		Transform Cloud = Clouds[current];
		if(Cloud.position.x<=EndX+1){
			Reset(Cloud);
		}
		Vector3 Target = new Vector3(EndX,Cloud.position.y,Cloud.position.z);
		Cloud.position = Vector3.MoveTowards(Cloud.position,Target,Time.deltaTime*Speed);
	}
	void Reset(Transform cloud){
		float y = Random.Range(RangeY.x,RangeY.y);
		float z = Random.Range(RangeZ.x,RangeZ.y);
		Vector3 pos = new Vector3(StartX,y,z);
		cloud.position = pos;
		
	}
}
