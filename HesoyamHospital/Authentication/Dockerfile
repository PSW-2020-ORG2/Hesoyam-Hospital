FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app/
COPY ./Authentication/bin/Release/netcoreapp3.1/ .
COPY ./Authentication/bin/Release/netcoreapp3.1/ /app/publish/
COPY ./Authentication ./Authentication
COPY ./Authentication .
COPY ./EventSourceClasses ./EventSourceClasses
COPY ./Authentication/Authentication.csproj .

WORKDIR /app/Authentication
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef --version 3.1.0
RUN dotnet-ef migrations add InitialCreate -p "Authentication.csproj"
# CMD [ "dotnet-ef", "database update" ]


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .

WORKDIR /app

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Authentication.dll