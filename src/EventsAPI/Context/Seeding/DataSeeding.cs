
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
            await SeedEvents(db);
        }
        catch {
            Console.WriteLine("Exception Caught during data seeding");
        }
    }

    /// <summary>
    /// Simple/Basic event types included!
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    static async Task SeedEventTypes(this ApplicationContext db)
    {
        if(db.EventTypes.Any())
            return;
        
        //List<EventType> types = new List<EventType>();
        
        db.EventTypes.Add(new EventType("N/A", true));
        db.EventTypes.Add(new EventType("Sport", true));
        db.EventTypes.Add(new EventType("Music", true));
        db.EventTypes.Add(new EventType("Technology", true));
        db.EventTypes.Add(new EventType("Misc", true));

        await db.SaveChangesAsync();
    }

    static async Task SeedEvents(this ApplicationContext db)
    {
        if(db.Events.Any())
            return;

        List<Event> evnts = new List<Event>();

        evnts.Add(new Event("Test Event One", DateTime.Now, 10, "Armagh", false));
        evnts.Add(new Event("Test Event Two", DateTime.Now, 60, "Armagh", true));

        await db.Events.AddRangeAsync(evnts);
        await db.SaveChangesAsync();
    }
}