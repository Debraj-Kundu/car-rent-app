﻿using Microsoft.AspNetCore.Http;
using System;

namespace WebAPI.Service
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        void RemoveImage(string fileName);
    }
}