﻿using KiloCall.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KiloCall.Core.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(x => true).ToList();
                return result;
            }
        }
        
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}