FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/admin/ATS.Admin.UI.csproj", "src/admin/"]
RUN dotnet restore "src/admin/ATS.Admin.UI.csproj"
COPY . .
WORKDIR "/src/src/admin"
RUN dotnet build "ATS.Admin.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ATS.Admin.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ATS.Admin.UI.dll"]