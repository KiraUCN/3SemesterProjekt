﻿namespace WebshopRestService.DTOs 
{
    public class PersonDTOWrite 
    {
        public PersonDTOWrite(string? firstName, string? lastName, string? phoneNo, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Email = email;   
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
    }
}
