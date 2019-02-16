//using NServiceBus;
//using System.Threading.Tasks;

//namespace HackatonBus.Suppliers
//{
//    public class EndpointInstance
//    {
//        private IEndpointInstance _endPointInstance;

//        public async Task Configure()
//        {
//            const string license = "<?xml version='1.0' encoding='utf-8'?><license type='Trial' Applications='All' expiration='2019-03-17' id='c0e4d189-9daf-415f-be1c-8e00fa18e7c7'><name>nils.larsen@ffcg.se</name><Signature xmlns='http://www.w3.org/2000/09/xmldsig#'><SignedInfo><CanonicalizationMethod Algorithm='http://www.w3.org/TR/2001/REC-xml-c14n-20010315' /><SignatureMethod Algorithm='http://www.w3.org/2000/09/xmldsig#rsa-sha1' /><Reference URI=''><Transforms><Transform Algorithm='http://www.w3.org/2000/09/xmldsig#enveloped-signature' /></Transforms><DigestMethod Algorithm='http://www.w3.org/2000/09/xmldsig#sha1' /><DigestValue>+Q1d5BH184k+lO0nW4X3srCNBjo=</DigestValue></Reference></SignedInfo><SignatureValue>DdDEjXxL+SughUeXw8tFUjwV/YigQHCuKrFpeZnetk91iU75ugh2mPsoDFpWi2zGdvCOIlhkUBF0dOnlLvu23fHkGLGFzfowrWGCmM2r8oshSF8ZZWqt4kXFjkSZrnb0xMxa+MZfQ/ZoqRuObnPQMDDgRTT/5kwpcUqo8VOfS2Y=</SignatureValue></Signature></license>";
//            const string connectionString = "Endpoint=sb://globalburgers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YuiGusws/1RA085fWTtzbpDCt/9W7ZkY/lK+TT7ifHg=";
//            var endpointConfiguration = new EndpointConfiguration("suppliers");

//            endpointConfiguration.License(license);
//            endpointConfiguration.EnableInstallers();
//            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
//            var routing = transport.Routing();
//            routing.RouteToEndpoint(typeof(Grocery), "suppliers");

//            transport.ConnectionString(connectionString);

//            var endpointInstance = await Endpoint.Start(endpointConfiguration)
//                .ConfigureAwait(false);

//            _endPointInstance = endpointInstance;
//        }

//        //public async Task Send(Grocery grocery)
//        //{
//        //    await _endPointInstance.Send(grocery)
//        ////        .ConfigureAwait(false);
//        //}
//    }
//}