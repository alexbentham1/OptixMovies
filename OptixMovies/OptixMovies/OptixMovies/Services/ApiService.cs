﻿using Microsoft.AspNetCore.Components;

namespace OptixMovies.Services
{
    public class ApiService
    {
        public ApiService(HttpClient httpClient, NavigationManager navigationManager)
        {
            HttpClient = httpClient;
            NavigationManager = navigationManager;
            HttpClient.BaseAddress = new Uri(NavigationManager.BaseUri);
        }

        public HttpClient HttpClient { get; }
        public NavigationManager NavigationManager { get; }
    }
}