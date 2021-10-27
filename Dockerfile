FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
WORKDIR /app
COPY ./src/RFE.Service.FT.Web/Publish .
RUN rm -rf '/app/*.pdb'
EXPOSE 80
ARG TCBUILDNUMBER
ARG GITHASH
ENV TCBUILDNUMBER=$TCBUILDNUMBER
ENV GITHASH=$GITHASH
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://*:80
ENTRYPOINT ["dotnet", "RFE.Service.FT.Web.dll"]