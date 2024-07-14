﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiberBooks.Books;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(
        this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        string? connectionString = configurationManager.GetConnectionString("BooksConnectionString");
        services.AddDbContext<BookDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IBookRepository, EfBookRepository>();
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}
