using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace redtag90.Models
{
    public class Product
    {
        public int ProductId {get;set;}

        [Required(ErrorMessage="Please enter a product name")]
        public string title {get;set;}

        [Required(ErrorMessage="Please enter a description")]
        public string description {get;set;}

        [Required(ErrorMessage="Please enter a price")]
        public int price {get;set;}
        
        public int quantity {get;set;}

        [Required(ErrorMessage="Please enter a time")]
        [RegularExpression(@"^[0-9*#+]+$", ErrorMessage = "Time must only contain numbers and/or special characters")]
        public int time {get;set;}

        public int redtag {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}