using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    static ArrayList room_numbers = new ArrayList(){2,3,4,5,6};
    public GameObject player;

    public Transform getTeleportDestination() {
        int index = Random.Range(0, room_numbers.Count);
        int num = (int)room_numbers[index];
        room_numbers.Remove(num);
        Transform Room = GameObject.Find("Room" + num).transform.Find("Teleporter");
        return Room;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform teleportDestination = getTeleportDestination();
            player.transform.position = teleportDestination.position;
            Physics.SyncTransforms();
        }
    }


}
