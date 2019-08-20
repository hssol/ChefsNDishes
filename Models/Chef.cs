using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    public int Age {get;set;}
    public List<Dish> CreatedDishes {get;set;}
    }
    public class Dish
    {
    [Key]
    public int DishId {get;set;}

    [Required]
    public string Name {get;set;}

    [Required]
    [Range(0,10000)]
    public int Calories {get;set;}

    [Required]
    [Range(0,5)]
    public int Tastiness {get;set;}

    [Required]
    public string Description {get;set;}
    
    public int ChefId {get;set;}
    
    public Chef Creator {get;set;}
    
    }

}

