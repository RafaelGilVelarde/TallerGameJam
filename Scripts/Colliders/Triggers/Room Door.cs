using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    [SerializeField] GameObject Current, NextRoom, DestinationPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomManager room= RoomManager.roomManager;
            Player.player.ChangeControllable();
            room.DestinationPosition=DestinationPosition;
            room.Current=Current;
            room.NextRoom=NextRoom;
            //ScreenTransition.screenTransition.changeSignal += ChangeRoom;
            ScreenTransition.screenTransition.Begin();
        }
    }

    public void ChangeRoom()
    {
    }
}
