using System.Collections;
using System.Text.RegularExpressions;

namespace edu_rooms_api.Models;

public class Room {

    private static int _idCounter;
    public int Id { get; }
    private string _name = string.Empty;
    public string Name {
        get => _name;
        set {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Room name cannot be empty", nameof(value));
            if (!Regex.IsMatch(value, @"^[A-Za-z]"))
                throw new ArgumentException("Room must starts with some letter", nameof(value));
            _name = value;
        }
    }
    private char _buildingCode;
    public char BuildingCode {
        get => _buildingCode;
        set {
            if (!char.IsAsciiLetterUpper(value)) 
                throw new ArgumentException("Building code must be ASCII upper letter", nameof(value));
            _buildingCode = value;
        }
    }
    public int Floor { get; }
    private int _capacity;
    public int Capacity {
        get => _capacity;
        set {
            if (value < 1)
                throw new ArgumentException("Minimum allowed capacity is 1");
            _capacity = value;
        }
    }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }

    public Room(string name, char buildingCode, int floor, int capacity, bool hasProjector) {
        Id = ++_idCounter;
        Name = name;
        BuildingCode = buildingCode;
        Floor = floor;
        Capacity = capacity;
        HasProjector = hasProjector;
        IsActive = true;
    }
    
}