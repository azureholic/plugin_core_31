using Microsoft.Extensions.DependencyInjection;
using SharedDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPlugin {
    public class CustomerServiceConfiguration : IPluginFactory 
    {
        public void Configure(IServiceCollection services) {
            services.AddSingleton<ICustomerService, CustomerService>();
        }
    }
}
