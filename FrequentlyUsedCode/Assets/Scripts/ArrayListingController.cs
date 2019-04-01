using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexeyAyusheevTools
{
	public class ArrayListingController 
	{

		public int CurrentIndex;
		public int ArrayLength;
		public string PlayerPrefsKey;
		/// <summary>
		/// Constructor for array listing controller
		/// </summary>
		/// <param name="playerPrefsKey"> PlayerPrefs key to read from and write current intex.</param>
		/// <param name="arrayLength">Length of list or array</param>
		/// <param name="DefaultIndexBeforeWritingInPlayerPrefs">If PlayerPrefs key not exists, this value (index) will assigned to this PlayerPrefs key</param>
		public  ArrayListingController(string playerPrefsKey, int arrayLength, int DefaultIndexBeforeWritingInPlayerPrefs)
		{
			ArrayLength = arrayLength;
			PlayerPrefsKey = playerPrefsKey;
			if (PlayerPrefs.HasKey(playerPrefsKey))
			{
				CurrentIndex = PlayerPrefs.GetInt(playerPrefsKey);
			}
			else
			{
				CurrentIndex = DefaultIndexBeforeWritingInPlayerPrefs;
				PlayerPrefs.SetInt(playerPrefsKey, DefaultIndexBeforeWritingInPlayerPrefs);
			}

		}

		
		
		/// <summary>
		/// 
		/// just give it increment
		/// </summary>
		/// <param name="incrementor">-1 or 1 (previous or next item</param>
		/// <returns></returns>
		public int GetIncrementedIndex(int incrementor)
		{


			CurrentIndex = PlayerPrefs.GetInt(PlayerPrefsKey);

			CurrentIndex = CurrentIndex + incrementor;

			CurrentIndex = CurrentIndex % ArrayLength;
			if (CurrentIndex < 0)
			{
				CurrentIndex = CurrentIndex + ArrayLength;

			}
			else
			if (CurrentIndex >= ArrayLength)
			{
				CurrentIndex = CurrentIndex - ArrayLength;

			}

			PlayerPrefs.SetInt(PlayerPrefsKey, CurrentIndex);
			return CurrentIndex;
		}
	}

}