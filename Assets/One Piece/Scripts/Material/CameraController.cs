/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player"; // Set the player tag in the Unity editor

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            Debug.LogError("Player not found with tag: " + playerTag);
        }
    }
}



//Room camera
/* [SerializeField] private float speed;
 private float currentPosX;
 private Vector3 velocity = Vector3.zero;

//Follow player
[SerializeField] private Transform player;
[SerializeField] private float aheadDistance;
[SerializeField] private float cameraSpeed;
private float lookAhead;

private void Update()
{
    Room camera
    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

    //Follow player
    transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
}

public void MoveToNewRoom(Transform _newRoom)
{
    currentPosX = _newRoom.position.x;
}*/

