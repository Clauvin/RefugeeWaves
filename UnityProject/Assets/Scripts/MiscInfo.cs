using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MiscInfo {

	//holds random info, like variable types

	public enum variableTypes{
		//int and float "normal" values(i.e., not percentage)
		legalPopulation,
		playerCurrentMoney,
		baseTaxPerCitizen,
		budgetBaseValue,
		availableHouses,
		totalHouses,
		costOfHouse,
		socialResources,
		costOfSocialResources,
		availableBO,
		totalBO,
		costOfBO,
		borderResources,
		costOfBorderResources,

		//percentage values
		publicOpinion,
		internationalOpinion,
		criminalityRate,
		unemployementRate,
		taxVariation,

		NULL
	}



}
