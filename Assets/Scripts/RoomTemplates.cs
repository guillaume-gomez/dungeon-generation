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

  public float waitTime = 10.0f;
  public GameObject boss;
  public float nbMinimalRoom = 5;

  public List<GameObject> rooms;
  private bool spawnedBoss;


  void Update() {
    if(waitTime <= 0 && spawnedBoss == false) {
      //check if the maze fit the number of rooms
      if (rooms.Count > nbMinimalRoom) {
        GameObject lastRoom = rooms[rooms.Count - 1];
        Instantiate(boss, lastRoom.transform.position, Quaternion.identity);
        spawnedBoss = true;
      } else {
        DestroyRoomAndRestart();
        waitTime = 10.0f;
      }
    } else {
      waitTime -= Time.deltaTime;
    }
  }

  void DestroyRoomAndRestart() {
    for (int i = 0; i < rooms.Count; i++) {
      RoomScript roomScript = rooms[i].GetComponent<RoomScript>();
      if(!roomScript.HasChildren()) {
        // destroy room
        roomScript.Remove();
        //Debug.Break();
        Destroy(rooms[i].gameObject);
        rooms.Remove(rooms[i]);
        return;
      }
    }
  }

}
