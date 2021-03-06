using System.Reflection;
using AutoMapper;
using gspark.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace gspark.Service.Common.Mappings;

public class UrlResolver<T, V> : IValueResolver<T, V, string> where T :class
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
        if (imagePath.GetValue(source) == null)
        {
            return _configuration["ApiUrl"] + "images/users/user_undefined.jpg";
        }
        if (imagePath.GetValue(source).ToString().Contains("images/users/user_undefined.jpg"))
        {
            return _configuration["ApiUrl"] + imagePath.GetValue(source);
        }

        return imagePath.GetValue(source).ToString();
    }
}