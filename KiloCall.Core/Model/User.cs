﻿using System;

namespace KiloCall.Core.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        public int Id { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рожддения.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - BirthDay.Year;
        //if(BirthDay > nowDate.AddYears(-age)) age--;

        public int Age 
        {
            get 
            {
                return DateTime.Now.Year - BirthDay.Year; 
            }
        }
        #endregion
        public User(){}
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthday"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthday, double weight, double height)
        {
            #region Проверка входных параметров

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));
            }

            if (birthday < DateTime.Parse("01.01.1900") || birthday >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthday));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю.", nameof(height));
            } 
            #endregion           

            Name = name;
            Gender = gender;
            BirthDay = birthday;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
