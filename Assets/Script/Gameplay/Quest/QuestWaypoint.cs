using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWaypoint : MonoBehaviour
{
    public static QuestWaypoint instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Quest")]
    [SerializeField] private Transform questLocation;
    [SerializeField] private RectTransform waypointUI;
    [SerializeField] private bool questDirectionActive;

    [Header("UI")]
    [SerializeField] private GameObject waypointPanel;

    [Header("Setting")]
    [SerializeField] private float margin = 50f;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (questDirectionActive)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(questLocation.position);

            if (screenPos.z < 0)
            {
                screenPos *= -1;
            }

            float minX = margin;
            float maxX = Screen.width - margin;
            float minY = margin;
            float maxY = Screen.height - margin;
            bool isOffScreen = screenPos.x <= minX || screenPos.x >= maxX || screenPos.y <= minY || screenPos.y >= maxY;

            // Batasi koordinat panah di dalam layar
            float clampedX = Mathf.Clamp(screenPos.x, minX, maxX);
            float clampedY = Mathf.Clamp(screenPos.y, minY, maxY);

            waypointUI.position = new Vector3(clampedX, clampedY, 0);

            // 3. Atur rotasi panah agar menunjuk ke target
            if (isOffScreen)
            {
                waypointUI.gameObject.SetActive(true); // Tampilkan panah jika di luar layar
                RotateArrowTowardsTarget(clampedX, clampedY);
            }
            else
            {
                waypointUI.gameObject.SetActive(false);
            }
        }

    }
    void RotateArrowTowardsTarget(float arrowX, float arrowY)
    {
        // Hitung arah dari posisi panah di layar ke posisi target sebenarnya di layar
        Vector3 targetScreenPos = mainCamera.WorldToScreenPoint(questLocation.position);
        Vector3 direction = targetScreenPos - new Vector3(arrowX, arrowY, 0);

        // Hitung sudut rotasi (Z-axis untuk 2D)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Terapkan rotasi ke UI Panah
        waypointUI.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void QuestLocationOn(Transform thisLocation)
    {
        waypointPanel.SetActive(true);
        questLocation = thisLocation;
        questDirectionActive = true;
    }

    public void QuestLocationOff()
    {
        questDirectionActive = false;
        questLocation = null;
        waypointPanel.SetActive(false);

    }
}
