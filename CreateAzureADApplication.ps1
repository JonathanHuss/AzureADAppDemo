##  Update these parameters appropriately
$appName = "Demo App"
$appIdentifier = "http://localhost/DemoApp"
$certOutputLocation = “C:\Temp\DemoApp”  ## This folder needs to exist
$certName = "DemoApp"
$certPassword = "SuperSecretPassword"
##

$certCerFile = Join-Path $certOutputLocation "$certName.cer"
$certPfxFile = Join-Path $certOutputLocation "$certName.pfx"

$securePassword = ConvertTo-SecureString $certPassword -AsPlainText -Force

$cert = New-SelfSignedCertificate -KeyLength 2048 -KeyExportPolicy Exportable -FriendlyName "CN=$certName" -CertStoreLocation Cert:\CurrentUser\My -Subject $certName -Provider "Microsoft Enhanced RSA and AES Cryptographic Provider"
Export-Certificate -Cert $cert -FilePath $certCerFile -type CERT | Out-Null
Export-PfxCertificate -Cert $cert -FilePath $certPfxFile -Password $securePassword | Out-Null

Remove-Item -Path "Cert:\CurrentUser\My\$($cert.Thumbprint)"

Login-AzureRmAccount | Out-Null

$cer = New-Object System.Security.Cryptography.X509Certificates.X509Certificate
$cer.Import($certCerFile)
$binCert = $cer.GetRawCertData()
$credValue = [System.Convert]::ToBase64String($binCert)

$newApp = New-AzureRmADApplication -DisplayName $appName -IdentifierUris $appIdentifier -CertValue $credValue

Write-Host "PFX: $certPfxFile"
Write-Host "PFX Password: $certPassword"
Write-Host "Azure App ID: $($newApp.ApplicationId)"
