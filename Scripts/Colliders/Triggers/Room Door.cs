using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    [SerializeField] Vector2 Destination;
    [SerializeField] GameObject Current, NextRoom;
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
            Player.player.ChangeControllable();
            ScreenTransition.screenTransition.changeSignal += ChangeRoom;
            ScreenTransition.screenTransition.Begin();
        }
    }

    public void ChangeRoom()
    {
        Player.player.transform.parent.position = Destination;
        Current.SetActive(false);
        NextRoom.SetActive(true);
        //NextRoom.GetComponentInChildren<CinemachineConfiner2D>().m_BoundingShape2D=NextRoom.GetComponent<PolygonCollider2D>();
        Player.player.ChangeControllable();
        ScreenTransition.screenTransition.changeSignal -= ChangeRoom;
    }
}
