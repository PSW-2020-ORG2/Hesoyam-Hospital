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
CMD [ "dotnet-ef", "database update" ]

FROM node:14.15.1-buster as nodebuilder
RUN mkdir /usr/src/app
WORKDIR /usr/src/app
ENV PATH /usr/src/app/node_modules/.bin:$PATH
COPY web-application-front/package.json /usr/src/app/package.json
RUN npm install
COPY web-application-front/. /usr/src/app
#RUN npm run build
RUN ng build --prod


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 as runtime

EXPOSE 80

WORKDIR /app/

COPY --from=build /app .
#COPY --from=build /app/Resources /app/publish/Resources
COPY --from=nodebuilder /usr/src/app/dist/web-application-front/. /app/Public/

WORKDIR /app

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll
#ENTRYPOINT [ "dotnet", "WebApplication.dll" ]