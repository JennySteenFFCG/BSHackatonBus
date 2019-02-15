using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using System.Threading.Tasks;

namespace HackatonBus.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var endpointConfiguration = new EndpointConfiguration("Grocery.Receive");
            const string license = "<?xml version='1.0' encoding='utf-8'?><license type='Trial' Applications='All' expiration='2019-03-17' id='c0e4d189-9daf-415f-be1c-8e00fa18e7c7'><name>nils.larsen@ffcg.se</name><Signature xmlns='http://www.w3.org/2000/09/xmldsig#'><SignedInfo><CanonicalizationMethod Algorithm='http://www.w3.org/TR/2001/REC-xml-c14n-20010315' /><SignatureMethod Algorithm='http://www.w3.org/2000/09/xmldsig#rsa-sha1' /><Reference URI=''><Transforms><Transform Algorithm='http://www.w3.org/2000/09/xmldsig#enveloped-signature' /></Transforms><DigestMethod Algorithm='http://www.w3.org/2000/09/xmldsig#sha1' /><DigestValue>+Q1d5BH184k+lO0nW4X3srCNBjo=</DigestValue></Reference></SignedInfo><SignatureValue>DdDEjXxL+SughUeXw8tFUjwV/YigQHCuKrFpeZnetk91iU75ugh2mPsoDFpWi2zGdvCOIlhkUBF0dOnlLvu23fHkGLGFzfowrWGCmM2r8oshSF8ZZWqt4kXFjkSZrnb0xMxa+MZfQ/ZoqRuObnPQMDDgRTT/5kwpcUqo8VOfS2Y=</SignatureValue></Signature></license>";
            endpointConfiguration.License(license);
            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
            const string connectionString = "Endpoint=sb://globalburgers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YuiGusws/1RA085fWTtzbpDCt/9W7ZkY/lK+TT7ifHg=";
            transport.ConnectionString(connectionString);

            var endpointInstance = Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}