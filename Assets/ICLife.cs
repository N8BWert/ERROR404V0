using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICLife : MonoBehaviour
{
    public float startHealth = 10;
    public float currentHealth;
    public Transform spawnLocation;
    public GameObject Crystal;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
    }
    void DeathCheck()
    {
        if (currentHealth <= 0)
        {
            Instantiate(Crystal, spawnLocation.position, spawnLocation.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentHealth -= Time.deltaTime;
        }
    }
}
