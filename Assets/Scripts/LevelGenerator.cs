using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelGenerator : MonoBehaviour
{
    private Transform lastDoor;
    private Vector3 forward;
    public bool isWaiting = true;

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
            
            //AsyncOperationHandle<GameObject> doorHandle =
                //Addressables.LoadAssetAsync<GameObject>($"Assets/Prefabs/Door.prefab");

            yield return roomHandle;
            //yield return doorHandle;

            GameObject room = Instantiate(roomHandle.Result);
            //GameObject door = Instantiate(doorHandle.Result);

            //door.transform.Rotate(Vector3.up, 90);

            // yield return new WaitUntil(() => !this.isWaiting);
            // this.isWaiting = true;

            Room roomData = room.GetComponent<Room>();
            roomData.id = i;

            if (this.lastDoor == null)
            {
                room.transform.position = Vector3.zero;
                this.lastDoor = roomData.outDoor;
                this.forward = this.lastDoor.forward;
                //door.transform.position = this.lastDoor.position;
            } else
            {
                room.transform.position = this.lastDoor.position;
                room.transform.rotation = Quaternion.LookRotation(this.lastDoor.forward);

                if (roomData.outDoor.forward == -this.forward)
                {
                    Debug.Log("Destruído");
                    Destroy(room);
                    continue;
                }

                Vector3 dist = roomData.entryDoor.position - room.transform.position;
                Vector3 localDist = room.transform.InverseTransformDirection(dist);
                room.transform.Translate(-localDist);

                this.lastDoor = roomData.outDoor;
            }
            i++;
        }
    }
}
