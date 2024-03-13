using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] ARRaycastManager aRRaycastManager;
    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] GameObject Board;
    [SerializeField] GameObject PlayerPiece;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    Camera arCamera;
    GameObject spawnedObject;

    void Start()
    {
        spawnedObject = null;
        arCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
        return;

        RaycastHit hit;
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);

        if(aRRaycastManager.Raycast(Input.GetTouch(0).position, hits))
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(hits[0].pose.position);
                    }
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = hits[0].pose.position;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }

    // Method to set the spawnablePrefab to Golf Ball prefab
    public void SetBoardPrefab()
    {
        spawnablePrefab = Board;
    }

    // Method to set the spawnablePrefab to Hole prefab
    public void SetPlayerPiecePrefab()
    {
        spawnablePrefab = PlayerPiece;
    }
}