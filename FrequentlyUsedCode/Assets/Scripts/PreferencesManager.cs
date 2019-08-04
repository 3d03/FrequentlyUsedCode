using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesManager : MonoBehaviour {
    public static PreferencesManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Double instance on SavedInfoManager");
        }
    }


    public bool isFirstMenuShowForThisMask(string objLabel)
    {
        if (PlayerPrefs.HasKey(objLabel + "_isFirstRun"))
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt(objLabel + "_isFirstRun", 0);

            //for (int i = 0; i < MaterialIconsAndNamesManager.instance.masks.Length; i++)
            //{
            //    PlayerPrefs.SetString(objLabel + "_lastActiveMatname", MaterialIconsAndNamesManager.instance.masks[i].GetComponent<Mask>().matNames[0] );
            //}
            return true;
        }
    }
	
    public void SetLastActiveMatName(string objLabel, string matName)
    {
        PlayerPrefs.SetString(objLabel + "_lastActiveMatname", matName);
    }

    public void SetLastActiveMatIndex(string objLabel, int matIndex)
    {
        PlayerPrefs.SetInt(objLabel + "_lastActiveMatIndex", matIndex);
    }


    public string GetLastActiveMatname(string objLabel)
    {
        if (PlayerPrefs.HasKey(objLabel + "_lastActiveMatname"))
            return PlayerPrefs.GetString(objLabel + "_lastActiveMatname");
        else
            return "Error Occured";
    }

    public string GetLastActiveMatIndex(string objLabel)
    {
        if (PlayerPrefs.HasKey(objLabel + "_lastActiveMatIndex"))
            return PlayerPrefs.GetString(objLabel + "_lastActiveMatIndex");
        else
            return "Error Occured";
    }
}
