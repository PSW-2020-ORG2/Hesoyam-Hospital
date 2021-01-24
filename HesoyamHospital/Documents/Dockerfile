FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app/
COPY ./Documents/bin/Release/netcoreapp3.1/ .
COPY ./Documents/bin/Release/netcoreapp3.1/ /app/publish/
COPY ./Documents ./Documents
COPY ./Documents .
COPY ./EventSourceClasses ./EventSourceClasses
COPY ./Documents/Documents.csproj .

# WORKDIR /app/Documents
# ENV PATH $PATH:/root/.dotnet/tools
# RUN dotnet tool install --global dotnet-ef --version 3.1.0
# RUN dotnet-ef migrations add InitialCreate -p "Documents.csproj"
# CMD [ "dotnet-ef", "database update" ]


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .

WORKDIR /app

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Documents.dll