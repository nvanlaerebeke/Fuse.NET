#!/bin/sh

assert_exists () {
  if ! type "$1" 2> /dev/null 1>&2 ; then
    echo "Error: '$1' not installed"
    exit 1
  fi
}

init_configuration () {
    if [ ! -z $1 ] 
    then 
        CONFIGURATION="$1"
    else
        CONFIGURATION="Release"
    fi
}

clean () {
    rm -rf "bin" "nativelibs"
}

build_managed () {
    dotnet build src/Fuse.NET/Fuse.NET.csproj -c "$CONFIGURATION"
}

build_native () {
    dotnet run -p src/CreateNativeMap/CreateNativeMap.csproj -c "$CONFIGURATION" --library=MonoFuseHelper "src/Fuse.NET/bin/$CONFIGURATION/net5.0/Fuse.NET.dll" buildlibs/map
    INCLUDES="-I/usr/include/glib-2.0 -I/usr/lib/x86_64-linux-gnu/glib-2.0/include -I/usr/include/fuse -I/usr/lib/glib-2.0/include -Ibuildlibs/"
    libtool --mode=compile gcc -D_FILE_OFFSET_BITS=64 $INCLUDES -g -O2 -MT buildlibs/mfh.lo -MD -MP -c -o buildlibs/mfh.lo src/MonoFuseHelper/mfh.c
    libtool --mode=compile gcc -D_FILE_OFFSET_BITS=64 $INCLUDES -g -O2 -MT buildlibs/map.lo -MD -MP -c -o buildlibs/map.lo buildlibs/map.c
    libtool --mode=link gcc -g -O2 -no-undefined -avoid-version -o buildlibs/libMonoFuseHelper.la -rpath /usr/local/lib buildlibs/mfh.lo buildlibs/map.lo -lglib-2.0 -lfuse -pthread

    if [ ! -d "nativelibs/linux-x64" ];
    then
        mkdir -p "nativelibs/linux-x64"
    fi
    mv buildlibs/.libs/libMonoFuseHelper.so "nativelibs/linux-x64"
}

build_samples () {
    dotnet build Samples/HelloFS/HelloFS.csproj -c "$CONFIGURATION"
    dotnet build Samples/RedirectFS/RedirectFS.csproj -c "$CONFIGURATION"
    dotnet build Samples/RedirectFS-FH/RedirectFS-FH.csproj -c "$CONFIGURATION"

    if [ ! -d "bin" ]:
    then
        mkdir "bin"
    fi

    cp -R Samples/HelloFS/bin/"$CONFIGURATION"/net5.0 ./bin/HelloFS
    cp -R Samples/RedirectFS/bin/"$CONFIGURATION"/net5.0 ./bin/RedirectFS
    cp -R Samples/RedirectFS-FH/bin/"$CONFIGURATION"/net5.0 ./bin/RedirectFS-FH
}

assert_exists dotnet
assert_exists libtool
assert_exists gcc
init_configuration
clean
build_native
build_managed
build_samples