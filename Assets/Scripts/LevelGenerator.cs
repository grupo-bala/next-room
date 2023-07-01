using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class LevelGenerator : MonoBehaviour
{
    private Transform lastDoor;
    private Vector3 initForward;
    private Vector3 lastForward;
    private Vector3 penultimateForward;
    public void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        int i = 1;
        while (i <= 100)
        {
            int roomId = Random.Range(2, 7);
            AsyncOperationHandle<GameObject> roomHandle =
                Addressables.LoadAssetAsync<GameObject>($"Assets/Prefabs/Rooms/Room {roomId}.prefab");

            yield return roomHandle;

            GameObject room = Instantiate(roomHandle.Result);

            Room roomData = room.GetComponent<Room>();
            roomData.id = i;

            if (this.lastDoor == null)
            {
                room.transform.position = Vector3.zero;
                this.lastDoor = roomData.outDoor;
                this.initForward = this.lastDoor.forward;
                this.lastForward = this.initForward;
                this.penultimateForward = this.lastForward;
            } else
            {
                room.transform.position = this.lastDoor.position;
                room.transform.rotation = Quaternion.LookRotation(this.lastDoor.forward);

                if (roomData.outDoor.forward == -this.initForward || roomData.outDoor.forward == -this.lastForward || roomData.outDoor.forward == -this.penultimateForward)
                {
                    Debug.Log("Destruído");
                    Destroy(room);
                    continue;
                }

                Vector3 dist = roomData.entryDoor.position - room.transform.position;
                Vector3 localDist = room.transform.InverseTransformDirection(dist);
                room.transform.Translate(-localDist);

                this.lastDoor = roomData.outDoor;
                this.penultimateForward = this.lastForward;
                this.lastForward = roomData.outDoor.forward;
            }

            i++;
        }

        AsyncOperationHandle<GameObject> playerHandle =
                Addressables.LoadAssetAsync<GameObject>($"Assets/Prefabs/Player/Player.prefab");
        
        yield return playerHandle;

        GameObject player = Instantiate(playerHandle.Result);
        player.transform.position = Vector3.zero;
    }
}
