using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MapTransition : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CinemachineConfiner2D cinemachineConfiner;

    [Header("Setting")]
    [SerializeField] private Vector3 vector3AddPos;
    private Vector3 vector3CurrentPos;

    void Start()
    {
        if(cinemachineConfiner == null)
        {
            cinemachineConfiner = FindObjectOfType<CinemachineConfiner2D>();
        }
        vector3CurrentPos = transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineConfiner.m_BoundingShape2D = boxCollider;
            UpdatePlayerLocation(collision.gameObject);
        }
    }

    public void UpdatePlayerLocation(GameObject player)
    {
        player.transform.position = vector3CurrentPos + vector3AddPos;
    }
}
