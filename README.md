# RichillCapital.TraderStudio.Desktop

[![RichillCapital.TraderStudio.Desktop CI](https://github.com/MengsyueAmaoTsai/TraderStudio.Desktop.Wpf/actions/workflows/ci.yml/badge.svg)](https://github.com/MengsyueAmaoTsai/TraderStudio.Desktop.Wpf/actions/workflows/ci.yml)

[![RichillCapital.TraderStudio.Desktop CD](https://github.com/MengsyueAmaoTsai/TraderStudio.Desktop.Wpf/actions/workflows/cd.yml/badge.svg)](https://github.com/MengsyueAmaoTsai/TraderStudio.Desktop.Wpf/actions/workflows/cd.yml)

## Publish

```bash
# Decode Signing Certificate
./Certs/Decode.ps1

# Publish AppPackages
msbuild ./Packaging/RichillCapital.TraderStudio.Desktop.Package/RichillCapital.TraderStudio.Desktop.Package.wapproj /p:Platform=x64 /p:Configuration=Release /p:UapAppxPackageBuildMode=SideloadOnly /p:AppxBundle=Never /p:PackageCertificateKeyFile=RichillCapital.TraderStudio.Desktop.pfx /p:PackageCertificatePassword=Pa55w0rd!

# Remove Signing Certificate
./Certs/Remove.ps1
```
