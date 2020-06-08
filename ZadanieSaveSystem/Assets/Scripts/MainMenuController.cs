using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject SaveTilePrefab;

    public Transform TilesParent;

    public InputField newPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        LoadTiles();
    }
    public void LoadTiles()
    {
#if UNITY_EDITOR
        string path = Application.streamingAssetsPath;
#elif UNITY_ANDROID
        string path = Application.persistentDataPath;
#endif
        string[] files = Directory.GetFiles(path);

        foreach(string file in files)
        {
            char[] separators = { '/', '\\', '.' };

            string[] tokens = file.Split(separators);
            if (file.Split(separators)[tokens.Length - 1].Equals("meta"))
                continue;
            string saveName = file.Split(separators)[tokens.Length-2];
            var tile = Instantiate(SaveTilePrefab, TilesParent).GetComponent<SaveTile>();
            tile.SetData(saveName);
        }
    }
    public void StartNewGame()
    {
        if (newPlayerName.text.Length > 2)
        {
            SaveManager.instance.NewGame(newPlayerName.text);
        }
        else
        {
            //error
        }
    }
}
