# RichillCapital.TraderStudio.Desktop

## Build & Publish

## Development

### Restore Dependencies

```bash
dotnet cake --target restore
```

### Build the Project

```bash
dotnet cake --target build
```

### Run

```bash
dotnet cake --target dev
```

```bash
dotnet cake --target publish && ./publish/RichillCapital.TraderStudio.Desktop.exe
```

```bash
msbuild ./Packaging/RichillCapital.TraderStudio.Desktop.Setup/RichillCapital.TraderStudio.Desktop.Setup.wapproj /p:Configuration=Release /p:Platform=x64 /p:OutputDirectory=./release
```
