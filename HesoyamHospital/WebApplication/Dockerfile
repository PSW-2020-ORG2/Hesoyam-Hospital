FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

# RUN groupadd -g 1024 appuser && \
#     useradd -r -u 1024 -g appuser appuser

# USER appuser

WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .
COPY ./WebApplication/bin/Release/netcoreapp3.1/ /app/publish
COPY ./WebApplication .
COPY ./WebApplication ./WebApplication

COPY ./WebApplication/WebApplication.csproj .

ENV PATH $PATH:/root/.dotnet/tools
COPY ./Backend ./Backend/
WORKDIR /app/Backend
RUN dotnet tool install --global dotnet-ef --version 3.1.0
RUN dotnet-ef migrations script -p "Backend.csproj" -o /app/sql/init.sql


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 as runtime

EXPOSE 80

WORKDIR /app

COPY --from=build /app .
COPY --from=build /app/sql /app/sql
COPY --from=build /app/WebApplication /app/publish

WORKDIR /app/sql
VOLUME /app/sql

WORKDIR /app/publish
#ENTRYPOINT ["dotnet", "WebApplication.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll