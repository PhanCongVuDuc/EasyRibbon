# Contributing to EasyRibbon

Thank you for your interest in contributing to EasyRibbon! We welcome contributions from the community.

## How to Contribute

### Reporting Bugs

If you find a bug, please create an issue on GitHub with:

- Clear description of the problem
- Steps to reproduce
- Expected behavior vs actual behavior
- Revit version you're using
- Screenshots if applicable

### Suggesting Features

We love new ideas! Please create an issue with:

- Clear description of the feature
- Use cases and examples
- Why this would be useful

### Pull Requests

1. **Fork the repository**
   ```bash
   git clone https://github.com/PhanCongVuDuc/EasyRibbon.git
   ```

2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes**
    - Write clean, readable code
    - Follow the existing code style
    - Add comments for complex logic
    - Test your changes thoroughly

4. **Commit your changes**
   ```bash
   git commit -m "Add: brief description of your changes"
   ```

   Use clear commit messages:
    - `Add:` for new features
    - `Fix:` for bug fixes
    - `Update:` for updates to existing features
    - `Refactor:` for code refactoring
    - `Docs:` for documentation changes

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create a Pull Request**
    - Describe what your PR does
    - Reference any related issues
    - Include screenshots if UI changes

## Code Style Guidelines

### C# Coding Standards

- Use meaningful variable and method names
- Follow C# naming conventions:
    - PascalCase for classes, methods, properties
    - camelCase for local variables
    - _camelCase for private fields
- Add XML documentation comments for public APIs
- Keep methods focused and small

### Comments

- Write comments in English
- Explain WHY, not WHAT (code should be self-explanatory)
- Update comments when code changes

### Example

```csharp
/// <summary>
/// Creates ribbon UI from attribute-decorated classes
/// </summary>
/// <typeparam name="T">Class containing tab definitions</typeparam>
/// <param name="application">Revit UI application</param>
public static void CreateUI<T>(UIControlledApplication application)
{
    // Implementation here
}
```

## Testing

- Test your changes with different Revit versions if possible
- Ensure existing functionality still works
- Test edge cases

## Documentation

- Update README.md if you add new features
- Add code examples for new attributes or functionality
- Update XML comments for public APIs

## Questions?

If you have questions, feel free to:

- Open an issue for discussion
- Ask in your Pull Request

## Code of Conduct

- Be respectful and constructive
- Welcome newcomers
- Focus on what is best for the community
- Show empathy towards other community members

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to EasyRibbon! 🚀

