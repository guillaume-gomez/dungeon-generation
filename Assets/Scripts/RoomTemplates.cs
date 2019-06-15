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

  public List<GameObject> rooms;

  public float waitTime = 2.0f;
  private bool spawnedBoss;
  public GameObject boss;


  void Update() {
    if(waitTime <= 0 && spawnedBoss == false) {
      GameObject lastRoom = rooms[rooms.Count - 1];
      Instantiate(boss, lastRoom.transform.position, Quaternion.identity);
      spawnedBoss = true;
    } else {
      waitTime -= Time.deltaTime;
    }
  }

}
