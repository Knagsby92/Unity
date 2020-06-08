using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject PlayerPrefab;
    public PlayerController3D player;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void StartGame(string name)
    {
        var obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            player = obj.GetComponent<PlayerController3D>();
        }
        else
        {
            /*
            float posX = 0;
            float posZ = 0;
            
            if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerZ"))
            {
                posX = PlayerPrefs.GetFloat("PlayerX");
                posZ = PlayerPrefs.GetFloat("PlayerZ");
            }
            */
            PlayerData data = SaveSystem.LoadGame(name);


            obj = Instantiate(PlayerPrefab, new Vector3(0, 0 , -20), Quaternion.identity);
            player = obj.GetComponent<PlayerController3D>();
            player.stats.Level = data.Level;
            player.stats.Name = data.Name;
            player.stats.Experience = data.Experience;
            player.stats.health = data.Health;
            player.SetPosition(new Vector3(data.posX, 0, data.posZ));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (player != null)
            {
                Debug.Log("Position saved!");
                SaveSystem.SaveGame(player);
            }
        }
    }

    private void SavePlayerPosition()
    {
        if (player != null)
        {
            Debug.Log("Position saved!");
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        }
    }
    public int GetLevel()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            return player.stats.Level;
        }
        else
        {
            return 0;
        }
    }
    public int GetExp()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            return player.stats.Experience;
        }
        else
        {
            return 0;
        }
    }
    public float GetHealth()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            return player.stats.health;
        }
        else
        {
            return 0f;
        }
    }
    public string GetName()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            return player.stats.Name;
        }
        else
        {
            return null;
        }
    }
}