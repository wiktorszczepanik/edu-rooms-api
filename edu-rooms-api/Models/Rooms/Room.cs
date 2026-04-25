using System.Text.RegularExpressions;

namespace edu_rooms_api.Models;

public class Room {

    private static int _idCounter;
    public int Id { get; init; }
    public Name Name { get; private set; }
    public BuildingCode BuildingCode { get; private set; }
    public int Floor { get; private set; }
    public Capacity Capacity { get; private set; }
    public bool HasProjector { get; private set; }
    public bool IsActive { get; private set; }

    private Room(Name name, BuildingCode buildingCode, int floor, Capacity capacity, bool hasProjector) {
        Id = ++_idCounter;
        Name = name;
        BuildingCode = buildingCode;
        Floor = floor;
        Capacity = capacity;
        HasProjector = hasProjector;
        IsActive = true;
    }

    public static Room Create(string name, char buildingCode, int floor, int capacity, bool hasProjector) {
        return new Room(
            new Name(name), 
            new BuildingCode(buildingCode), 
            floor, 
            new Capacity(capacity), 
            hasProjector
        );
    }
    
}