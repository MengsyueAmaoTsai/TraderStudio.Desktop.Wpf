# RichillCapital.TraderStudio.Desktop

## Build

```bash
msbuild .\RichillCapital.TraderStudio.Desktop.sln /p:Platform=x64 /p:Configuration=Release /p:UapAppxPackageBuildMode=SideloadOnly /p:AppxBundle=Never /p:PackageCertificateKeyFile=Certs/RichillCapital.TraderStudio.Desktop.pfx
```

```bash
certutil -encode ./Certs/RichillCapital.TraderStudio.Desktop.pfx ./Certs/RichillCapital.TraderStudio.Desktop.asc
```
