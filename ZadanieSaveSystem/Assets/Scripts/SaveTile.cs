using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveTile : MonoBehaviour
{
    string SaveName;
    public Text NameText;
    public void SetData(string name)
    {
        SaveName = name;
        NameText.text = name;
    }
    public void LoadPlayer()
    {
        SaveManager.instance.LoadGame(SaveName);
    }

}
