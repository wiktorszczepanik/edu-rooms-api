namespace edu_rooms_api.Models;

public class OrganizerName {
    
    public string Value { get; private set; }

    public OrganizerName(string organizerName) {
        if (string.IsNullOrEmpty(organizerName))
            throw new ArgumentException("Organizer name cannot be null or empty", nameof(organizerName));
        Value = organizerName;
    }
    
}