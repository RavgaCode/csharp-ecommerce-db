﻿// See https://aka.ms/new-console-template for more information
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Order> Orders { get; set; }
}