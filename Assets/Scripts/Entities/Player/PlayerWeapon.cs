using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerWeapon : NetworkBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private InputAction mousePos;
    [SerializeField] private InputAction shootButton;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float reload;

    private List<Bullet> bullets = new List<Bullet>();
    private float lastShootTime;

    private void Start()
    {
        mousePos.Enable();
        shootButton.Enable();
    }

    private void Update()
    {
        
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos.ReadValue<Vector2>());
        mouseWorldPos.z = 0;
        spawnPoint.position = (mouseWorldPos - transform.position).normalized + transform.position;
        
        if (shootButton.ReadValue<float>() > 0 && Time.time - lastShootTime > reload)
        {
            lastShootTime = Time.time;
            SpawnBulletRequest(spawnPoint.position, spawnPoint.position - transform.position);
        }
    }

    [Command]
    private void SpawnBulletRequest(Vector2 spawnPos, Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bullet.transform.right = direction;
        NetworkServer.Spawn(bullet.gameObject);
    }

    
}
