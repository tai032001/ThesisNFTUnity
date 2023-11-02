using UnityEngine;
using UnityEngine.UI;
using Thirdweb;

public class ClaimTokenScript : MonoBehaviour
{
    [SerializeField] Text CherriesEarned;
    [SerializeField] Button ClaimButton;
    // public string ERC_20_Owner_Contract = "0x73B04Ba5B071c6302Dc7fB9e132E5102F49bcF4D";
    public static string ERC_20_DropContract = "0x117Ed9670840c7722994098568c2EDd9BdFbeFcC";
    // public static string ERC_20_New = "0x659a1497306b2225a261e6b85789bD641C290EcD";
    public Contract myContract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_DropContract);
    void Start()
    {

        CherriesEarned.text = "You have earn: " + ItemCollector.cherries.ToString() + " Cherries";
    }

    public async void claimToken()
    {
        try
        {
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
            throw;
        }
    }

}
