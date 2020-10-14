# Company-Site
h2 Строка подключения к БД хранится в файле appsettings.json 
 ` "ConnectionString": "Data Source = WIN-2GGAI1J1JRQ\\SQLEXPRESS; Database=dbCompanyBtw; 
                                    Persist Security Info=false; User ID='sa'; Password='sa';
                                    MultipleActiveResultSets=True; Trusted_Connection=False;", ` 

h2 Логин и пароль администратора
` User Admin
Login: "admin";
Password: "admin"; `

h2 Migration 
`  dotnet tool install --global dotnet-ef --version 3.1.4 `
если не создается миграция, то нужно установить инструмент, но или установить пакет NuGet "Microsoft.EntityFrameworkCore.Tools"

h2 Созданеи миграций (консоль в папке проекта)
` dotnet ef migrations add _Initial `

h2 Создание БД по последней миграции БД будет называться "dbCompanyBtw"
` dotnet ef database update `
