using System.Collections;
using System.Collections.Generic;
using Thirdweb;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //pass cherries through scene
    public static int cherries = 0;
    // public static int cherriesEarned;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    public void Awake()
    {
        cherriesText.text = "Cherries have earned: " + cherries;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries have earned: " + cherries;
        }

    }
    public async void ClaimToken()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x117Ed9670840c7722994098568c2EDd9BdFbeFcC");
            var result = await contract.ERC20.Claim(cherries.ToString());
            Debug.Log("Claim Success");
            // CherriesEarned.text = "Claim Token Successfully";
            // CherriesEarned.text = address;
            // ClaimButton.gameObject.SetActive(false);
        }
        catch (System.Exception)
        {
            Debug.Log("Claim Failed ");
            // CherriesEarned.text = "Claim failed";
            // ClaimButton.gameObject.SetActive(false);
            throw;
        }
    }
}
