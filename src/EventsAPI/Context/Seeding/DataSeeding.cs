
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsAPI.Models;

namespace EventsAPI.Context.Seeding;

public static class DataSeeding
{

    public async static Task TrySeedData(this ApplicationContext db)
    {
        try
        {
            await SeedEventTypes(db);
        }
        catch {
            Console.WriteLine("There is an issue!");
        }
    }

    static async Task SeedEventTypes(this ApplicationContext db)
    {
        if(db.EventTypes.Any())
            return;
        
        List<EventType> types = new List<EventType>();
        
        db.EventTypes.Add(new EventType("Default", true));
        db.EventTypes.Add(new EventType("Indoor Football", true));

        await db.SaveChangesAsync();
    }
}