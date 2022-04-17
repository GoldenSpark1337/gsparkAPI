﻿namespace gspark.Service.Specification.Messages;

public class MessageSpecParams
{
    public string? Username { get; set; }
    public string Container { get; set; } = "All";
    
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 20;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}