using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private List<GameObject> parents;
    private List<GameObject> children;
    private List<string> spawnersName;
    private RoomTemplates templates;

    void Awake() {
      parents = new List<GameObject>();
      children = new List<GameObject>();
      // get the spawners
      foreach (Transform child in transform)
      {
        if(child.name.Constains("SpawnPoint")) {
          spawners.Add(child.name);
        }
      }
    }

    void Start() {
      // add room in template
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      templates.rooms.Add(gameObject);
    }

    public void AddParent(GameObject parent) {
      parents.Add(parent);
    }

    public void RemoveParent(GameObject parent) {
      parents.Remove(parent);
    }

    public void RemoveAllParent() {
      parents.Clear();
    }

    public void AddChild(GameObject child) {
      children.Add(child);
    }

    public void RemoveChild(GameObject child) {
      children.Remove(child);
    }

    public void RemoveAllChildren() {
      children.Clear();
    }

    public bool HasParent() {
      return NbParents() > 0;
    }

    public int NbParents() {
      return parents.Count;
    }

    public bool HasChildren() {
      return NbChildren() > 0;
    }

    public int NbChildren() {
      return children.Count;
    }

    public void Remove() {
      foreach(GameObject parent in parents) {
        foreach(Transform child in parent.transform) {
          if(child.CompareTag("SpawnPoint")) {
            switch(child.name) {
              case "SpawnPointTop":
                if(spawners.Contains("SpawnPointBottom")) {
                  //RoomSpawner spawner = child.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointBottom":
                if(spawners.Contains("SpawnPointTop")) {
                  //RoomSpawner spawner = child.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointLeft":
                if(spawners.Contains("SpawnPointRight")) {
                  //RoomSpawner spawner = child.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointRight":
                if(spawners.Contains("SpawnPointLeft")) {
                  //RoomSpawner spawner = child.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
            }
          }
        }
      }
      Debug.Log(gameObject.name);
    }
}
