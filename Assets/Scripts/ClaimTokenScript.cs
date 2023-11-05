using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using UnityEngine.SceneManagement;

public class ClaimTokenScript : MonoBehaviour
{
    [SerializeField] Text CherriesEarned;
    [SerializeField] Button ClaimButton;
    public static string ERC_20_DropContract = "0x117Ed9670840c7722994098568c2EDd9BdFbeFcC";
    // public Contract myContract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_DropContract);
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
            // var transfer = await myContract.ERC20.Claim(ItemCollector.cherries.ToString());
            var result = await myContract.ERC20.Claim(ItemCollector.cherries.ToString());
            CherriesEarned.text = "Claim Token Successfully";
            // CherriesEarned.text = address;
            ClaimButton.gameObject.SetActive(false);

        }
        catch (System.Exception)
        {
            CherriesEarned.text = "Claim failed";
            ClaimButton.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            throw;
        }
    }

}
