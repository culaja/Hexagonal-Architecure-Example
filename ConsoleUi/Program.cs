﻿using System;
using Domain;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BookService("mongodb://localhost:27017/");
            bookService.AddBook("War and Peace");
            bookService.BorrowBook("War and Peace", "John Doe");
        }
    }
}