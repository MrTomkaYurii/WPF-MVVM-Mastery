namespace DataTemplatesShowcase.Models;
public abstract record FeedItem(string Author, DateTime Timestamp);
public record TextPost(string Author, DateTime Timestamp, string Message) : FeedItem(Author, Timestamp);
public record AlertPost(string Author, DateTime Timestamp, string AlertLevel, string Details) : FeedItem(Author, Timestamp);
