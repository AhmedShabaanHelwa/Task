cd .\Task

heroku login
heroku container:login

dotnet publish -c Release

docker build -t examplenetcore ./bin/release/netcoreapp3.1/publish

docker tag examplenetcore registry.heroku.com/a7mah1/web

docker push registry.heroku.com/a7mah1/web

heroku container:release web -a a7mah1