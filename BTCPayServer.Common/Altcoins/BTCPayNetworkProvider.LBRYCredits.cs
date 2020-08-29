using NBitcoin;
using NBXplorer;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitLBRYCredits()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("LBC");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "LBRYCredits",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "https://explorer.lbry.com/tx/{0}" : "https://explorer.lbry.com/tx/{0}",
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "lbrycredits",
                DefaultRateRules = new[]
                {
                                "LBC_X = LBC_BTC * LBC_X",
                                "LBC_BTC = bittrex(LBC_BTC)"
                },
                CryptoImagePath = "imlegacy/lbrycredits.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("31'") : new KeyPath("1'")
            });
        }
    }
}
