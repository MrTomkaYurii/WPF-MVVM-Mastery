namespace GenericHostShowcase.Services;
public interface IUserService { string GetCurrentUserName(); }
public class UserService : IUserService { public string GetCurrentUserName() => "Yurii Tomka (Senior WPF Architect)"; }
