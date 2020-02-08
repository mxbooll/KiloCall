﻿using KiloCall.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KiloCall.Core.Controller
{
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatig();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(x => x.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEatig()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        public void Save()
        {
            Save(Foods);
            Save(new List<Eating> { Eating });
        }
    }
}
