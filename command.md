# Dotnet & Migrations commands
* dotnet new list
* dotnet new sln
* dotnet new webapi -n Api
* dotnet new classlib -n Core
* dotnet new classlib -n Infrastructure
* dotnet sln add Api
* dotnet sln add Core
* dotnet sln add Infrastructure
* dotnet add reference ../Infrastructure
* dotnet add reference ../Core
* dotnet restore
* dotnet new gitignore
* dotnet watch --no-hot-reload

* dotnet tool install --global dotnet-ef --version 7.0.10 / dotnet tool update --global dotnet-ef --version 7.0.10 
* dotnet build
* dotnet ef migrations add InitialCreate -p Infrastructure -s Api -o Data/Migrations
* dotnet ef database drop -p Infrastructure -s Api
* dotnet ef migrations remove -p Infrastructure -s Api (xoa migration mới nhất và trả về mô hình snapshot cho migration kế tiếp, nếu migration tồn tại trong cơ sở dữ liệu nó sẽ ném ra lỗi ngoại lệ.)

