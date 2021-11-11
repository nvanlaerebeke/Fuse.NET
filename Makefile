.PHONY: build clean push
CONFIGURATION=Release
REGISTRY:=""
APIKEY:=""

build: clean
	dotnet build src/Fuse.NET/Fuse.NET.csproj -c $(CONFIGURATION)
	
clean:
	rm -rf src/*/bin/ src/*/obj/ 
	
libs:
	./build.sh
	
push: build
	dotnet nuget push src/Fuse.NET/bin/$(CONFIGURATION)/*.nupkg -s "$(REGISTRY)" -k "$(APIKEY)"
