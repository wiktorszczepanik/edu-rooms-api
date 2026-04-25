namespace edu_rooms_api.Models;

public class Topic {
    
    public string Value { get; private set; }

    public Topic(string topic) {
        if (topic.Length < 1) {
            throw new ArgumentException("Topic must be at least 1 char long");
        }
        Value = topic ?? throw new ArgumentNullException(nameof(topic));
    }
    
}