﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    public class Base
    {
        public Base()
        {
            
        }

        public Base(string path)
        {
            Path = path;
        }
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}
