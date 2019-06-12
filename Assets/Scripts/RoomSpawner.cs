using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 bottom door
    // 2 top door
    // 3 left door
    // 4 right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start() {
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      Invoke("Spawn", templates.waitTime % 0.25f);
      //Destroy(gameObject, templates.waitTime * 2.0f);
    }

    void Spawn()
    {
      if(spawned) {
        return;
      }

      switch(openingDirection) {
        case 1:
          //  bottom
          instanciateRoom(templates.topRooms);
        break;
        case 2:
          //  top
          instanciateRoom(templates.bottomRooms);
        break;
        case 3:
          //  left
          instanciateRoom(templates.rightRooms);
        break;
        case 4:
          //  right
          instanciateRoom(templates.leftRooms);
        break;
      }
      spawned = true;
    }

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("SpawnPoint")) {
      if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
      {
        Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
        Destroy(gameObject);
      }
      spawned = true;
    }
  }

  private void instanciateRoom(GameObject[] rooms) {
    rand = Random.Range(0, rooms.Length);
    GameObject room = rooms[rand];
    Instantiate(room, transform.position, room.transform.rotation);
  }
}
