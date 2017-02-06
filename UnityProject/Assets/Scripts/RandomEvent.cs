using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent {
	//Random event; Has a name, a description and a consequence

	string name;
	string description;

	MiscInfo.variableTypes consequenceVariable1;//Variable that suffers from this event
	float consequenceValue1;
	MiscInfo.variableTypes consequenceVariable2;//Possible second variable that suffers from this event
	float consequenceValue2;

	public RandomEvent(string n, string desc, MiscInfo.variableTypes var1, float consequence1, MiscInfo.variableTypes var2=MiscInfo.variableTypes.NULL, float consequence2=0.0f)
	{
		name = n;
		description = desc;
		consequenceVariable1 = var1;
		consequenceValue1 = consequence1;
		consequenceVariable2 = var2;
		consequenceValue2 = consequence2;
	}



}
