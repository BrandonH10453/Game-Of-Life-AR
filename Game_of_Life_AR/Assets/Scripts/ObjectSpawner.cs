using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] ARRaycastManager aRRaycastManager;
    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] GameObject Board;
    [SerializeField] GameObject Player1Piece;
    [SerializeField] GameObject Player2Piece;
    [SerializeField] Button BoardButton;
    [SerializeField] Button Player1Button;
    [SerializeField] Button Player2Button;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    Camera arCamera;
    GameObject spawnedObject;
    bool objectSpawned = false;

    void Start()
    {
        spawnedObject = null;
        arCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
        var hits = new List<ARRaycastHit>();

        if (aRRaycastManager.Raycast(Input.GetTouch(0).position, hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        if (spawnablePrefab != null && !objectSpawned)
                        {
                            SpawnPrefab(hits[0].pose.position);
                            objectSpawned = true;

                            // Hide the button once object is spawned
                            if (spawnablePrefab == Board)
                            BoardButton.gameObject.SetActive(false);
                            else if (spawnablePrefab == Player1Piece)
                            Player1Button.gameObject.SetActive(false);
                            else if (spawnablePrefab == Player2Piece)
                            Player2Button.gameObject.SetActive(false);
                        }
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }

    // Method to set the spawnablePrefab to Board prefab
    public void SetBoardPrefab()
    {
        spawnablePrefab = Board;
        objectSpawned = false;
        BoardButton.gameObject.SetActive(false);
    }

    // Method to set the spawnablePrefab to Player1Piece prefab
    public void SetPlayer1PiecePrefab()
    {
        spawnablePrefab = Player1Piece;
        objectSpawned = false;
        Player1Button.gameObject.SetActive(false);
    }

    // Method to set the spawnablePrefab to Player2Piece prefab
    public void SetPlayer2PiecePrefab()
    {
        spawnablePrefab = Player2Piece;
        objectSpawned = false;
        Player2Button.gameObject.SetActive(false);
    }
}