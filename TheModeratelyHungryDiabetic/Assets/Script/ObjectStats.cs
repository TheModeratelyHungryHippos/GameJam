using UnityEngine;
using System;
using System.Collections;

public enum QType{
	Avoidable,
	Blocking,
	FullRoom,
	Moving
}
public enum Direction{
	None,
	LeftRight,
	UpDown
}

public class ObjectStats : object{
	public string Name;
	public int ID;
	public QType QType;
	public Direction Direction;
	public int Weight;
	public Transform Prefab;

	public ObjectStats(string name, int id, QType qType, Direction direction, int weight, Transform prefab)
	{
		Name = name;
		ID = id;
		this.QType = qType;
		this.Direction = direction;
		Weight = weight;
		Prefab = prefab;

	}
		
}
