using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class InvoiceModel : PageModel
{
    // Properties for the travel booking details
    public int Days { get; set; }
    public int Adults { get; set; }
    public int ChildrenWithBed { get; set; }
    public int ChildrenWithoutBed { get; set; }
    public int Rooms { get; set; }
    public string Vehicle { get; set; } = string.Empty; // Default to empty string

    // Properties for costs
    public decimal AdultCostPerHead { get; set; } = 100m; // Example value
    public decimal ChildWithBedCostPerHead { get; set; } = 70m; // Example value
    public decimal ChildWithoutBedCostPerHead { get; set; } = 50m; // Example value
    public decimal RoomCostPerNight { get; set; } = 150m; // Example value
    public decimal VehicleCost { get; set; } = 200m; // Example value (depends on vehicle type)

    // Property for total cost calculation
    public decimal TotalCost =>
        (Adults * AdultCostPerHead) +
        (ChildrenWithBed * ChildWithBedCostPerHead) +
        (ChildrenWithoutBed * ChildWithoutBedCostPerHead) +
        (Rooms * RoomCostPerNight * Days) +
        VehicleCost;

    // Property for itinerary
    public List<string> Itinerary { get; set; } = new List<string>();

    public void OnGet(int days, int adults, int childrenWithBed, int childrenWithoutBed, int rooms, string vehicle)
    {
        // Assign the values passed from the form
        Days = days;
        Adults = adults;
        ChildrenWithBed = childrenWithBed;
        ChildrenWithoutBed = childrenWithoutBed;
        Rooms = rooms;
        Vehicle = vehicle;

        // Set the vehicle cost based on vehicle type
        switch (vehicle.ToLower())
        {
            case "car":
                VehicleCost = 100m;
                break;
            case "van":
                VehicleCost = 200m;
                break;
            case "bus":
                VehicleCost = 300m;
                break;
            default:
                VehicleCost = 0m;
                break;
        }

        // Generate itinerary based on the number of days
        GenerateItinerary(days);
    }

    private void GenerateItinerary(int days)
    {
        // You can modify the itinerary for different day ranges
        switch (days)
        {
            case 2:
                Itinerary.Add("Day 1: Arrival in Singapore, visit Marina Bay Sands.");
                Itinerary.Add("Day 2: Sentosa Island tour, return flight.");
                break;
            case 3:
                Itinerary.Add("Day 1: Arrival in Singapore, visit Marina Bay Sands.");
                Itinerary.Add("Day 2: Sentosa Island and Universal Studios tour.");
                Itinerary.Add("Day 3: Gardens by the Bay, return flight.");
                break;
            case 4:
                Itinerary.Add("Day 1: Arrival in Singapore, visit Marina Bay Sands.");
                Itinerary.Add("Day 2: Sentosa Island and Universal Studios tour.");
                Itinerary.Add("Day 3: Gardens by the Bay, shopping at Orchard Road.");
                Itinerary.Add("Day 4: Free day and return flight.");
                break;
            default:
                Itinerary.Add("Custom itinerary will be provided.");
                break;
        }
    }
}
