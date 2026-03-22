# Autorizacion.Middleware

Middleware de ASP.NET Core 8 que consulta los perfiles (roles) del usuario
autenticado en la base de datos de seguridad y los agrega como `Claim`
al `HttpContext.User`.

## Paso 1 - Configurar el feed de GitHub Packages (una sola vez por máquina)

Crea un PAT en tu cuenta GitHub con scope `read:packages`, luego ejecuta:

```powershell
dotnet nuget add source [https://nuget.pkg.github.com/SC-701/index.json](https://nuget.pkg.github.com/SC-701/index.json) `
  --name github `
  --username TU_USUARIO_GITHUB `
  --password TU_PERSONAL_ACCESS_TOKEN `
  --store-password-in-clear-text