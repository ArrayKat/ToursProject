﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API_Tours.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountOfStars { get; set; }

    public string CountryCode { get; set; } = null!;

    public string? Description { get; set; }

    [JsonIgnore]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
