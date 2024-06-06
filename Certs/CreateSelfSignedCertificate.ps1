$currentDate = Get-Date
$extendedDate = $currentDate.AddYears(3)
$subject = "CN=RichillCapital"
$location = "Cert:\CurrentUser\My"
$dnsName = "richillcapital.trader-studio-desktop"
$output = "./Certs/RichillCapital.TraderStudio.Desktop.pfx"

$cert = New-SelfSignedCertificate -Subject $subject -CertStoreLocation $location -DnsName $dnsName -NotAfter $extendedDate -KeyUsage DigitalSignature -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")
$password = ConvertTo-SecureString -String Pa55w0rd! -Force -AsPlainText
$path = $location + "/" + $cert.thumbprint

Export-PfxCertificate -cert $path -FilePath $output -Password $password