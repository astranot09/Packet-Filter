using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 3f;
    public float waitTime = 1f;
    public bool loopWaypoints = true;

    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private int maxWaypoint;
    private bool isWaiting;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // FIX: Jangan lupa assign komponen Rigidbody2D

        maxWaypoint = waypointParent.childCount;
        waypoints = new Transform[maxWaypoint];
        for (int i = 0; i < maxWaypoint; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    private void Update()
    {
        if (isWaiting) return;

        // FIX: Panggil fungsi pergerakan di Update (atau FixedUpdate karena menggunakan Rigidbody)
        MoveToWayPoint();
    }

    private void MoveToWayPoint()
    {
        // Pengaman jika tidak ada waypoint
        if (maxWaypoint == 0) return;

        Transform target = waypoints[currentWaypointIndex];

        // FIX: Hitung arah dan gerakkan posisi Rigidbody secara halus menggunakan MoveTowards
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target.position, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);

        // FIX: Cek jarak posisi objek saat ini (rb.position) ke posisi target
        if (Vector2.Distance(rb.position, target.position) < 0.05f)
        {
            StartCoroutine(WaitNextWayPoint());
        }
    }

    IEnumerator WaitNextWayPoint()
    {
        isWaiting = true;

        // FIX: Set velocity ke 0 agar objek benar-benar diam saat menunggu (tidak meluncur akibat sisa gaya)
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex++;

        // Logika Loop atau Stop jika sudah mencapai waypoint terakhir
        if (currentWaypointIndex >= maxWaypoint)
        {
            if (loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                currentWaypointIndex = maxWaypoint - 1;
                enabled = false; // Matikan script jika tidak loop dan sudah sampai akhir
            }
        }

        isWaiting = false; // FIX: Kembalikan menjadi false agar bisa bergerak lagi
    }
}