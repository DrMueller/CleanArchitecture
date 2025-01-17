﻿using JetBrains.Annotations;

namespace Mmu.CleanArchitecture.CrossCutting.Areas.Settings.Models
{
    [PublicAPI]
    public class SecuritySettings
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}