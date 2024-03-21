﻿using Microsoft.AspNetCore.Identity;

namespace crudemvccore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public string UserId {  get; set; }
        public IdentityUser User { get; set; }
        public int Quantity {  get; set; }

    }
}
