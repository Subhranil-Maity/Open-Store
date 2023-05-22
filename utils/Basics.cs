using System.Net.NetworkInformation;

namespace Open_Store
{
    internal class Basics{
        public static bool IsConnected(){
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}