using edu_rooms_api.Models;

namespace edu_rooms_api.Storage;

public class Data {

    public static List<Room> Rooms = new();
    public static List<Reservation> Reservations = new();

    public static void Seed() {
        // 5 rooms
        Rooms.Add(new Room("Conference room", 'A', 1, 10, false));
        Rooms.Add(new Room("Conference room", 'A', 2, 20, true));
        Rooms.Add(new Room("Conference room", 'A', 2, 20, false));
        Rooms.Add(new Room("Conference room", 'B', 1, 30, true));
        Rooms.Add(new Room("Conference room", 'B', 2, 20, true));
        
        // 6 Reservations
        Reservations.Add(
            new Reservation(
                1, 
                "Jan Kowalski", 
                "Wprowadzenie do baz danych", 
                new DateTime(2026, 5, 5, 14, 30, 0),
                new DateTime(2026, 5, 5, 16, 0, 0)
            )
        );
        Reservations.Add(
            new Reservation(
                1, 
                "Jan Kowalski", 
                "Wprowadzenie do baz danych", 
                new DateTime(2026, 5, 5, 16, 30, 0),
                new DateTime(2026, 5, 5, 18, 0, 0)
            )
        );
        Reservations.Add(
            new Reservation(
                2, 
                "Adam Nowak", 
                "Sieci komputerowe", 
                new DateTime(2026, 5, 5, 14, 30, 0),
                new DateTime(2026, 5, 5, 16, 0, 0)
            )
        );
        Reservations.Add(
            new Reservation(
                3, 
                "Adam Nowak", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 18, 0, 0),
                new DateTime(2026, 5, 5, 19, 30, 0)
            )
        );
        Reservations.Add(
            new Reservation(
                4, 
                "Jan Kowalski", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 10, 0, 0),
                new DateTime(2026, 5, 5, 11, 30, 0)
            )
        );
        Reservations.Add(
            new Reservation(
                5, 
                "Adam Nowak", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 12, 0, 0),
                new DateTime(2026, 5, 5, 13, 30, 0)
            )
        );
    }
    
}