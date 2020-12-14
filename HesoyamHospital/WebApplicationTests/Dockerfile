FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app/
WORKDIR /app/Backend/
WORKDIR /app/
COPY ./Backend /app/Backend
COPY ./WebApplication /app/WebApplication
COPY ./WebApplication/bin/Release/netcoreapp3.1/ .
COPY ./WebApplication/bin/Release/netcoreapp3.1/ /app/publish/
COPY ./WebApplication .
COPY ./WebApplication/WebApplication.csproj .

COPY ./WebApplicationTests /app/WebApplicationTests

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .
COPY --from=build /app/Resources /app/publish/Resources

WORKDIR /app/WebApplicationTests/

CMD ["dotnet", "test"]


# /app
#     /publish
#     /Backend
#     /WebApplication
#     /WebApplicationTests