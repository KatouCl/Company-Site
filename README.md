# Company-Site
## Строка подключения к БД хранится в файле appsettings.json 
 > ` "ConnectionString": "Data Source = WIN-2GGAI1J1JRQ\\SQLEXPRESS; Database=dbCompanyBtw; 
                                    Persist Security Info=false; User ID='sa'; Password='sa';
                                    MultipleActiveResultSets=True; Trusted_Connection=False;", ` 

## Логин и пароль администратора
 > ` User Admin
Login: "admin";
Password: "admin"; `

## Migration 
 > `  dotnet tool install --global dotnet-ef --version 3.1.4 `
 
если не создается миграция, то нужно установить инструмент, но или установить пакет NuGet "Microsoft.EntityFrameworkCore.Tools"

## Созданеи миграций (консоль в папке проекта)
 > ` dotnet ef migrations add _Initial `

## Создание БД по последней миграции БД будет называться "dbCompanyBtw"
 > ` dotnet ef database update `
