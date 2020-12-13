FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app/
WORKDIR /app/Backend/
WORKDIR /app/
COPY ./Backend ./Backend/
COPY ./WebApplication/bin/Release/netcoreapp3.1/ .
COPY ./WebApplication/bin/Release/netcoreapp3.1/ /app/publish/
COPY ./WebApplication .


COPY ./WebApplication/WebApplication.csproj .

WORKDIR /app/Backend
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef --version 3.1.0
RUN dotnet-ef migrations add InitialCreate -p "Backend.csproj"

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .
COPY --from=build /app/Resources /app/publish/Resources

WORKDIR /app/publish/

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll