using edu_rooms_api.Models;

namespace edu_rooms_api.Storage;

public class InMemoryData {

    public static List<Room> Rooms = new();
    public static List<Reservation> Reservations = new();

    public InMemoryData() {
        Seed();
    }

    public static void Seed() {
        // 6 rooms
        Rooms.Add(Room.Create("Conference room", 'A', 1, 10, false));
        Rooms.Add(Room.Create("Conference room", 'A', 2, 20, true));
        Rooms.Add(Room.Create("Conference room", 'A', 2, 20, false));
        Rooms.Add(Room.Create("Conference room", 'B', 1, 30, true));
        Rooms.Add(Room.Create("Conference room", 'B', 2, 20, true));
        Rooms.Add(Room.Create("Conference room", 'C', 3, 40, true));
        
        // 6 Reservations
        Reservations.Add(
            Reservation.Create(
                1, 
                "Jan Kowalski", 
                "Wprowadzenie do baz danych", 
                new DateTime(2026, 5, 5, 14, 30, 0),
                new DateTime(2026, 5, 5, 16, 0, 0)
            )
        );
        Reservations.Add(
            Reservation.Create(
                1, 
                "Jan Kowalski", 
                "Wprowadzenie do baz danych", 
                new DateTime(2026, 5, 5, 16, 30, 0),
                new DateTime(2026, 5, 5, 18, 0, 0)
            )
        );
        Reservations.Add(
            Reservation.Create(
                2, 
                "Adam Nowak", 
                "Sieci komputerowe", 
                new DateTime(2026, 5, 5, 14, 30, 0),
                new DateTime(2026, 5, 5, 16, 0, 0)
            )
        );
        Reservations.Add(
            Reservation.Create(
                3, 
                "Adam Nowak", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 18, 0, 0),
                new DateTime(2026, 5, 5, 19, 30, 0)
            )
        );
        Reservations.Add(
            Reservation.Create(
                4, 
                "Jan Kowalski", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 10, 0, 0),
                new DateTime(2026, 5, 5, 11, 30, 0)
            )
        );
        Reservations.Add(
            Reservation.Create(
                5, 
                "Adam Nowak", 
                "Programowanie obiektowe", 
                new DateTime(2026, 5, 5, 12, 0, 0),
                new DateTime(2026, 5, 5, 13, 30, 0)
            )
        );
    }
    
}