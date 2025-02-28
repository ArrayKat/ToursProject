﻿using System;
using System.Collections.Generic;

namespace API_Tours.Models;

public partial class ToursType
{
    public int Id { get; set; }

    public int TourId { get; set; }

    public int TypeId { get; set; }

    public virtual Tour Tour { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
