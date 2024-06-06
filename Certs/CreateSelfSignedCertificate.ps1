$currentDate = Get-Date
$extendedDate = $currentDate.AddYears(3)
$cert = New-SelfSignedCertificate -Subject "CN-RichillCapital" -CertStoreLocation "Cert:\CurrentUser\My" -DnsName richillcapital.trader-studio-desktop -NotAfter $extendedDate -KeyUsage DigitalSignature -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")
$password = ConvertTo-SecureString -String Pa55w0rd! -Force -AsPlainText
$path = "Cert:\CurrentUser\My\" + $cert.thumbprint

Export-PfxCertificate -cert $path -FilePath ./Certs/RichillCapital.TraderStudio.Desktop.pfx -Password $password