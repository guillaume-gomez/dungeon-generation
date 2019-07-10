using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //private List<GameObject> parents;
    //private List<GameObject> children;
    //private List<string> spawnersName;
    private RoomTemplates templates;

    void Awake() {
      /*parents = new List<GameObject>();
      children = new List<GameObject>();
      spawnersName = new List<string>();
      // get the spawners
      foreach (Transform child in transform)
      {
        if(child.name.Contains("SpawnPoint")) {
          spawnersName.Add(child.name);
        }
      }*/
    }

    void Start() {
      // add room in template
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      templates.rooms.Add(gameObject);
    }

    /*public void AddParent(GameObject parent) {
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
        foreach(Transform childParent in parent.transform) {
          if(childParent.CompareTag("SpawnPoint")) {
            switch(childParent.name) {
              case "SpawnPointTop":
                if(spawnersName.Contains("SpawnPointBottom")) {
                  RoomSpawner spawner = childParent.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointBottom":
                if(spawnersName.Contains("SpawnPointTop")) {
                  RoomSpawner spawner = childParent.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointLeft":
                if(spawnersName.Contains("SpawnPointRight")) {
                  RoomSpawner spawner = childParent.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
              case "SpawnPointRight":
                if(spawnersName.Contains("SpawnPointLeft")) {
                  RoomSpawner spawner = childParent.GetComponent<RoomSpawner>();
                  //spawner.Restart();
                }
              break;
            }
          }
        }
      }
      Debug.Log(gameObject.name);
    }*/
}
