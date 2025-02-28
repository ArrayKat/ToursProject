﻿using System;
using System.Collections.Generic;

namespace Client_Tours.Models;

public partial class TypeLocal
{
    public int Id { get; set; }

    public string Type1 { get; set; } = null!;

    public virtual ICollection<ToursType> ToursTypes { get; set; } = new List<ToursType>();
}
