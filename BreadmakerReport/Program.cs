using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using RatingAdjustment.Services;
using BreadmakerReport.Models;

namespace BreadmakerReport
{
    class Program
    {
        static string dbfile = @".\data\breadmakers.db";
        static RatingAdjustmentService ratingAdjustmentService = new RatingAdjustmentService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bread World");
            var BreadmakerDb = new BreadMakerSqliteContext(dbfile);
            var BMList = BreadmakerDb.Breadmakers
                // Query for title and reviews
                from BMreviews in BreadmakerDb.Breadmakers
                where BMreviews.title != null && BMreviews.reviews >= 0;
                select BMreviews;
                .ToList();

            Console.WriteLine("[#]  Reviews Average  Adjust    Description");
            for (var j = 0; j < 3; j++)
            {
                var i = BMList[j];
                //Outputs the first 3 products
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", [j+1], BMreviews.reviews, BMreviews.Average, RatingAdjustmentService.Adjust, BMreviews.title);
            }
        }
    }
}
