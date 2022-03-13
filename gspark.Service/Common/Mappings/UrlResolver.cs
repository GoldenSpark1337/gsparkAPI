using System.Reflection;
using AutoMapper;
using gspark.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace gspark.Service.Common.Mappings;

public class UrlResolver<T, V> : IValueResolver<T, V, string> where T : BaseEntity
{
    private readonly IConfiguration _configuration;

    public UrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Resolve(T source, V destination, string destMember, ResolutionContext context)
    {
        Type type = source.GetType();
        PropertyInfo imagePath = type.GetProperty("Image"); 
        return _configuration["ApiUrl"] + imagePath.GetValue(source);
    }
}