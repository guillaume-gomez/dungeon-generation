using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private List<GameObject> parents;
    private RoomTemplates templates;

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

    public bool HasParent() {
      return parents.Count > 0;
    }
}
