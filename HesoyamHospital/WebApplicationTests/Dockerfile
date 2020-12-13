FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app/
WORKDIR /app/Backend/
WORKDIR /app/
COPY ./Backend /app/Backend
RUN true
COPY ./WebApplication /app/WebApplication
RUN true
COPY ./WebApplication/bin/Release/netcoreapp3.1/ .
RUN true
COPY ./WebApplication/bin/Release/netcoreapp3.1/ /app/publish/
RUN true
COPY ./WebApplication .
RUN true
COPY ./WebApplication/WebApplication.csproj .
RUN true
COPY ./WebApplicationTests /app/WebApplicationTests

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .
RUN true
COPY --from=build /app/Resources /app/publish/Resources

WORKDIR /app/WebApplicationTests/

CMD ["dotnet", "test"]


# /app
#     /publish
#     /Backend
#     /WebApplication
#     /WebApplicationTests