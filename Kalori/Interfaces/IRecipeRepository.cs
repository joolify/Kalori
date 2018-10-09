﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> Get();
        Recipe Get(int id);
        void Add(Recipe recipe);
    }
}