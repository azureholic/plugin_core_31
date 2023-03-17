using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedDomain {
    public interface IPluginFactory {
        void Configure(IServiceCollection services);
    }
}
