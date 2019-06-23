using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
  public GameObject[] bottomRooms;
  public GameObject[] topRooms;
  public GameObject[] leftRooms;
  public GameObject[] rightRooms;

  public GameObject closedRoom;

  public float waitTime = 2.0f;
  public GameObject boss;
  public float nbMinimalRoom = 5;

  public List<GameObject> rooms;
  private bool spawnedBoss;


  void Update() {
    if(waitTime <= 0 && spawnedBoss == false) {
      GameObject lastRoom = rooms[rooms.Count - 1];
      Instantiate(boss, lastRoom.transform.position, Quaternion.identity);
      spawnedBoss = true;
    } else {
      waitTime -= Time.deltaTime;
    }
  }

  void DestroyRoomAndRestart() {
    for (int i = 0; i < rooms.Count; i++) {
      RoomScript roomScript = rooms[i].GetComponent<RoomScript>();
      if(roomScript.HasParent()) {
        // destroy room
        roomScript.Remove();
        return;
      }
    }
  }

}
