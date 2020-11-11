$params = @{
  Name = "GaiaService"
  BinaryPathName = "C:\Ripcord\Services\GaiaService\net5.0\GaiaService.Host.exe"
  DisplayName = "Gaia Service"
  StartupType = "Manual"
  Description = "Gaia service, a .net 5 gRPC service experiment."
}
New-Service @params