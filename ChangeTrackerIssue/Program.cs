// See https://aka.ms/new-console-template for more information
using ChangeTrackerIssue;
using ChangeTrackerIssue.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

Console.WriteLine("Hello, World!");

var arrangeContext = new AppDbContext();

arrangeContext.Database.EnsureDeleted();
arrangeContext.Database.EnsureCreated();

// Seed TimeUnits
arrangeContext.Add(TimeUnit.s);
arrangeContext.Add(TimeUnit.min);
arrangeContext.SaveChanges();

// Disable TimeUnit tracking
arrangeContext.AddTrackingEvents();

// Populate Db
var mainEntity1 = new MainEntity("MainEntity1", TimeUnit.s);
var mainEntity2 = new MainEntity("MainEntity2", TimeUnit.min);

arrangeContext.AddRange(mainEntity1, mainEntity2);
arrangeContext.SaveChanges();

var actContext = new AppDbContext();

// Disable TimeUnit tracking
actContext.AddTrackingEvents();

var mainEntities = actContext.MainEntities.Include(me => me.TimeUnit)
    .ToDictionary(me => me.Name);

// Normal case (problematic)
mainEntities["MainEntity1"].TimeUnit = TimeUnit.min;
mainEntities["MainEntity2"].TimeUnit = TimeUnit.s;
actContext.ChangeTracker.DetectChanges(); // After DetectChanges mainEntities["MainEntity2"].TimeUnit is set to TimeUnit.s

// Alternative case (calling DetectChanges after each assignment solves the problem)

mainEntities["MainEntity1"].TimeUnit = TimeUnit.min;
actContext.ChangeTracker.DetectChanges(); // Works correctly

mainEntities["MainEntity2"].TimeUnit = TimeUnit.s;
actContext.ChangeTracker.DetectChanges(); // Works correctly



