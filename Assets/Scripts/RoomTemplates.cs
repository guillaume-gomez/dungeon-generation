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

 /* void DestroyRoomAndRestart() {
    for (int i = rooms.Count - 1 ; i >= 0; i--) {
      RoomScript roomScript = rooms[i].GetComponent<RoomScript>();
      if(!roomScript.HasChildren()) {
        // destroy room
        roomScript.Remove();
        Destroy(rooms[i].gameObject);
        rooms.Remove(rooms[i]);
        return;
      }
    }
  }*/

}
