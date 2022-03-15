﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public enum RoomType {EnnemieRoom,BossRoom,ItemRoom,CoinRoom,StartRoom};
    public RoomType typeRoom;
    public Vector2Int roomPos;
    public bool isClear =false;
    GameObject[] ennemies;
    public List<Ennemis> currentRoomEnnemie = new List<Ennemis>();
    public GameObject victoire;
    public GameObject computer;
    public List<Case> availlibleSpawnCase;



    public GameObject tileRepresentingIt;

    private bool isDone = false;

    public Room northRoom = null;
    public Room southRoom = null;
    public Room eastRoom = null;
    public Room westRoom = null;

    public void Start()
    {
        SearchForEnnemie();
        findAvaillibleSpawn();

    }

    private void SearchForEnnemie()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Ennemi");
        foreach (GameObject ennemie in ennemies)
        {
            if (ennemie.transform.parent.name == this.gameObject.name)
            {
                currentRoomEnnemie.Add(ennemie.transform.GetComponent<Ennemis>());

            }
        }
    }

    private void findAvaillibleSpawn()
    {
        Case[] tuiles = transform.GetComponent<Grille>().TilesList;
        foreach (Case tuile in tuiles)
        {
            if (tuile.typeCase == Case.CaseType.Sol)
            {
                availlibleSpawnCase.Add(tuile);
            }
        }
    }

    private void Update()
    {
        // Debug.Log(currentRoomEnnemie.Count);
        if (currentRoomEnnemie.Count == 0)
        {
            isClear = true;
        }
        if (isClear)
        {
            if(typeRoom == RoomType.BossRoom)
            {
                if(isDone == false && roomName == "BoseRoom2")
                {
                    int random = UnityEngine.Random.Range(0, availlibleSpawnCase.Count);
                    Vector3 position = transform.GetComponent<Grille>().GridToWorld(availlibleSpawnCase[random].GridPos);
                    position.z = -0.5f;
                    GameObject levelEnd =Instantiate(victoire, position, Quaternion.identity);
                    levelEnd.transform.parent = this.transform;
                    isDone = true;
                }
                if (isDone == false && roomName == "BoseRoom")
                {
                    int random = UnityEngine.Random.Range(0, availlibleSpawnCase.Count);
                    Vector3 position = transform.GetComponent<Grille>().GridToWorld(availlibleSpawnCase[random].GridPos);
                    position.z = -0.5f;
                    GameObject levelEnd = Instantiate(computer, position, Quaternion.identity);
                    levelEnd.transform.parent = this.transform;
                    isDone = true;
                }

            }
        }
    }

}
