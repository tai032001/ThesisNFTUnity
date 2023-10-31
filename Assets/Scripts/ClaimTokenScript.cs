using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Threading.Tasks;
using Thirdweb.Examples;
using Nethereum.Contracts.QueryHandlers.MultiCall;
using Newtonsoft.Json;
public class ClaimTokenScript : MonoBehaviour
{
    [SerializeField] Text CherriesEarned;
    [SerializeField] Button ClaimButton;
    public string ERC_20_Owner_Contract = "0x73B04Ba5B071c6302Dc7fB9e132E5102F49bcF4D";
    public static string ERC_20_Contract = "0x117Ed9670840c7722994098568c2EDd9BdFbeFcC";
    // public Thirdweb.RelayerResult claim = JsonConvert.DeserializeObject<Thirdweb.RelayerResult>(ItemCollector.cherries.ToString());

    void Start()
    {
        CherriesEarned.text = "You have earn: " + ItemCollector.cherries.ToString() + " Cherries";
    }

    public async void claimToken()
    {

        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_Contract);
            var result = await contract.ERC20.Claim(ItemCollector.cherries.ToString());
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
