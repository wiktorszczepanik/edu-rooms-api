using System.Text.RegularExpressions;

namespace edu_rooms_api.Models;

public class Name {
    
    public string Value { get; private set; }

    public Name(string name) {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Room name cannot be empty", nameof(name));
        if (!Regex.IsMatch(name, @"^[A-Za-z]"))
            throw new ArgumentException("Room must starts with some letter", nameof(name));
        Value = name;
    }
    
}