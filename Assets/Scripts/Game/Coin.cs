using UnityEngine;

public class Coin : MonoBehaviour
{
    Bank bank;
    [SerializeField] int coinCost = 1;
    [SerializeField] AudioClip collectSound;

    void Awake()
    {
        Debug.Log("awake");
        bank = GameObject.Find("Bank").GetComponent<Bank>();
        collectSound = Resources.Load<AudioClip>("Sounds/Meow");
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("collision");
        if(other.CompareTag("Player"))
        {
            // Debug.Log("collision with PLAYER");
            bank.AddCoin(coinCost);
            if(collectSound)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
