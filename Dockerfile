# Set the base image as the .NET 8 SDK (this includes the runtime)
FROM mcr.microsoft.com/dotnet/sdk:8.0.303-jammy as build-env

# Copy everything and publish the release (publish implicitly restores and builds)
COPY . ./
RUN dotnet publish ./RandomPet/RandomPet.csproj -c Release -o out --no-self-contained

# Label the container
LABEL maintainer="Michael Bartels <bartelsm@outlook.com>"
LABEL repository="https://github.com/cyberbartels/random-pet"

# Label as GitHub action
LABEL com.github.actions.name=".NET random pet name generator"
LABEL com.github.actions.description="A Github action that creates random pet names."
LABEL com.github.actions.icon="sliders"
LABEL com.github.actions.color="purple"

# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/sdk:8.0.303-jammy
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/RandomPet.dll" ]