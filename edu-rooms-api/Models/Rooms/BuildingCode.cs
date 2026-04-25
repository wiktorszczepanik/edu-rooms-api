namespace edu_rooms_api.Models;

public class BuildingCode {
    
    public char Value { get; private set; }

    public BuildingCode(char buildingCode) {
        if (!char.IsAsciiLetter(buildingCode))
            throw new ArgumentException("Building code must be ASCII letter", nameof(buildingCode));
        buildingCode = char.ToUpper(buildingCode);
        Value = buildingCode;
    }
}