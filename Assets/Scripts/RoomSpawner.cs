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
    private RoomScript roomScript;
    private int rand;
    private bool spawned = false;

    void Start() {
      roomScript = gameObject.transform.parent.gameObject.GetComponent<RoomScript>();
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      Invoke("Spawn", templates.waitTime % 0.25f);
      //Destroy(gameObject, templates.waitTime * 2.0f);
    }

    public void Unspawn() {
      spawned = false;
    }

    public void Restart() {
      Unspawn();
      Spawn();
    }

    private void Spawn()
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
    GameObject childRoom = Instantiate(room, transform.position, room.transform.rotation);

    // room is not the final room of a path
    /*RoomScript childRoomScript = childRoom.GetComponent<RoomScript>();
    GameObject parent = gameObject.transform.parent.gameObject;
    childRoomScript.AddParent(parent);

    RoomScript parentRoomScript = parent.GetComponent<RoomScript>();
    parentRoomScript.AddChild(childRoom); */
  }
}
