using AutoMapper;
using gspark.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace gspark.Service.Common.Mappings;

public class UrlResolver<T> : IValueResolver<User, T, string>
{
    private readonly IConfiguration _configuration;

    public UrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Resolve(User source, T destination, string destMember, ResolutionContext context)
    {
        if (source.Image != null)
        {
            return _configuration["ApiUrl"];
        }

        return null;
    }
}