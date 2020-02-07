﻿using KiloCall.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KiloCall.Core.Controller
{
    public class ExerciseController : BaseController
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User _user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            _user = user ?? throw new System.ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(x => x.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, _user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, _user);
                Exercises.Add(exercise);
            }
                Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
