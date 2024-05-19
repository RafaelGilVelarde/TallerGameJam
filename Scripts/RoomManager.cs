using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager roomManager;
    public GameObject Current, NextRoom;
    public GameObject DestinationPosition;
    void Awake()
    {
        roomManager=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScreenTransition.screenTransition.changeSignal += ChangeRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(){
        Player.player.transform.parent.position = DestinationPosition.transform.position;
        Current.SetActive(false);
        NextRoom.SetActive(true);
        Current=NextRoom;
        //NextRoom.GetComponentInChildren<CinemachineConfiner2D>().m_BoundingShape2D=NextRoom.GetComponent<PolygonCollider2D>();
        Player.player.ChangeControllable();
    }
}
