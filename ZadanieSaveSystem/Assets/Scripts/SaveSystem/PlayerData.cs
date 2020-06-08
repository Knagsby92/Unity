using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float posX;
    public float posY;
    public float posZ;

    public float Health;
    public int Level;
    public int Experience;
    public String Name;

    public PlayerData(PlayerController3D controller)
    {
        posX = controller.transform.position.x;
        posY = controller.transform.position.y;
        posZ = controller.transform.position.z;
        Name = controller.stats.Name;
        Level = controller.stats.Level;
        Experience = controller.stats.Experience;
        Health = controller.stats.health;
    }

    public PlayerData()
    {
        posX = 0;
        posY = 0;
        posZ = 0;
        Name = "Player";
        Level = 1;
        Experience = 0;
        Health = 100f;
    }
    public PlayerData(string name)
    {
        posX = 0;
        posY = 0;
        posZ = 0;
        Name = name;
        Level = 1;
        Experience = 0;
        Health = 100f;
    }
}
