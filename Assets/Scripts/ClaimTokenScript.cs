using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using UnityEngine.SceneManagement;

public class ClaimTokenScript : MonoBehaviour
{
    [SerializeField] Text CherriesEarned;
    [SerializeField] Button ClaimButton;
    public static string ERC_20_DropContract = "0x117Ed9670840c7722994098568c2EDd9BdFbeFcC";
    public float timeRemaining = 5;
    public bool timeIsRunning = true;
    void Start()
    {

        CherriesEarned.text = "You have earn: " + ItemCollector.cherries.ToString() + " Cherries";
    }

    public async void claimToken()
    {
        try
        {
            Contract myContract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_DropContract);
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            var result = await myContract.ERC20.Claim(ItemCollector.cherries.ToString());
            CherriesEarned.text = "Claim Token Successfully";
            ClaimButton.gameObject.SetActive(false);
            //handle load to first scene
        }
        catch (System.Exception)
        {
            // Debug.Log()
            CherriesEarned.text = "Claim again ?";
            ClaimButton.gameObject.SetActive(true);
            throw;
        }
    }

}
