﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assignment1
{
    /// <summary>
    /// subclass of animal.
    /// 
    /// adds: breed
    /// </summary>
    public class Cat : Animal
    {
    
        public BreedEnum breed;
        
        //breed enumerator property
        public BreedEnum Breed
        {
            get { return breed; }
    
            set
            {
                //does not let user set breed past alloted limit
                if ((int)value > 6)
                {
                    Console.WriteLine("Error in setting breed. Value too high...");
                    Console.WriteLine("Breed set to default");
                    breed = (BreedEnum)1;
                }
                else
                    breed = value;
            }
            
        }
    
        public Cat()
        {
    
        }
        /// <summary>
        /// positon only constructor
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Cat(double xpos, double ypos, double zpos)
        {
            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;
        }
    
        /// <summary>
        /// All but breed. Breed is set to 1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Cat(string name, double age, int id, double xpos, double ypos, double zpos)
        {
            this.age = age;
            this.id = id;
            this.name = name;
    
            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;
    
            Breed = (BreedEnum)1;
        }
    
        /// <summary>
        /// full constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        /// <param name="breed"></param>
        public Cat(string name, double age, int id, double xpos, double ypos, double zpos, int breed)
        {
            this.age = age;
            this.id = id;
            this.name = name;
    
            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;
    
            Breed = (BreedEnum)breed;
        }
    
        public override string ToString()
        {
            //checks to be sure position has been given a value
            if (pos == null)
                return (" Name: " + name + " Age: " + age + " ID: " + id + " Position: " + " N/A" + " Breed: " + Breed.GetDisplayName());
            else
                return ("Name: " + name + " Age: " + age + " ID: " + id + " Position: " + pos.ToString() + " Breed: " + Breed.GetDisplayName()); 
        }
    }

    //breed enumerator
    public enum BreedEnum
    {
        Abyssinian,
        Bengal,
        [Display(Name = "Cornish Rex")] CornishRex,
        Himalayan,
        Ocicat,
        Serval
    }

    //I did not build the code below by myself.
    //reference https://benjaminray.com/codebase/c-enum-display-names-with-spaces-and-special-characters/
    //https://stackoverflow.com/questions/1101872/how-to-set-space-on-enum/31988435

    //enumerator extension
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }

            return displayName;
        }
    }
}